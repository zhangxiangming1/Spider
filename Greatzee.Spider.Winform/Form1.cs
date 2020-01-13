using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using Greatzee.Spider.Core;
using System.Net;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Web.Script.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Greatzee.Spider.Winform
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 嵌入的浏览器
        /// </summary>
        ChromiumWebBrowser browser;

        /// <summary>
        /// 后台的javascript代理
        /// </summary>
        ScriptBrige scriptBrige;

        /// <summary>
        /// 动作上下 文
        /// </summary>
        ActionContext context;

        /// <summary>
        /// 访问cookie
        /// </summary>
        CookieVisitor visitor = new CookieVisitor();

        public Form1()
        {
            InitializeComponent();
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;//使网页上的javascirpt能够调用后端的c#方法
            var settings = new CefSettings();
            settings.CachePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Cache";
            settings.PersistSessionCookies = true;
        }


        /// <summary>
        /// 加载主页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //载入爬虫的xml文件
            this.Log("正在读取配置文件");
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SpiderConfig");
            this.context = ActionLoad.CreateContext(path);
            if (this.context.Actions.Count > 0)
            {
                this.browser = new ChromiumWebBrowser(this.context.Actions[0].search_page_url);
                this.browser.FrameLoadEnd += FrameLoadEnd;
                this.scriptBrige = new ScriptBrige();
                this.browser.RegisterJsObject("ScriptBrige", this.scriptBrige);//使网页能够调用后端的javascirpt
                this.pnlMain.Controls.Add(this.browser);
                this.browser.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// 监听网页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            CefSharp.Cef.GetGlobalCookieManager().VisitAllCookies(visitor);//记录cookie
            if (this.context.CurrentIndex < this.context.Actions.Count)
            {
                ActionInfo action = this.context.Actions[this.context.CurrentIndex];
                Regex regResultPageUrl = new Regex(action.result_page_url_regex);//结果页面的正则表达式
                if (this.context.Searching && e.Frame.Url.Equals(action.search_page_url))
                {
                    //进入到了查询页面
                    this.Log($"正在执行[{action.name}]的查询函数");
                    string script = ActionLoad.GetJavaScript(action);//注入配置的javascript
                    script += "greatzee_execute_search();\r\n";//执行查询函数
                    e.Frame.ExecuteJavaScriptAsync(script);
                    this.context.Searching = false;
                }
                else if (regResultPageUrl.IsMatch(e.Frame.Url))
                {
                    //进入到了结果页面
                    string script = ActionLoad.GetJavaScript(action);//注入配置的javascript
                    string ticket = Guid.NewGuid().ToString();
                    script += "ScriptBrige.callRegisterParameter(JSON.stringify($RegisterParameter),'" + ticket + "');\r\n";    //通过ScriptBrige.CallRegisterParameters将$RegisterParameter传递到后台
                    e.Frame.ExecuteJavaScriptAsync(script);
                    this.scriptBrige.WaitTicket(ticket);//等待ScriptBrige.callRegisterParameter执行完

                    //将参数和Cookie拼凑在html后面，并将html页面发送给负责存储的应用程序
                    var html = await e.Frame.GetSourceAsync();
                    this.Log($"已查询到[{action.name}]的结果");
                    StringBuilder message = new StringBuilder();
                    message.AppendLine(html);
                    message.AppendLine("\r\n");
                    message.AppendLine("<script name='greatzee_parameter'><![CDATA[$RegisterParameter=" + this.scriptBrige.Parameters + ";]]></script>");
                    message.AppendLine("<script name='greatzee_cookie'><![CDATA[$Cookie=" + new JavaScriptSerializer().Serialize(this.visitor.Cookies) + "]]></script>");
                    Encoding encoding = Encoding.GetEncoding(action.charset);
                    byte[] htmlBytes = encoding.GetBytes(message.ToString());
                    HtmlStorage storage = new HtmlStorage();
                    storage.ExecuteStorage(action.storage_socket, action.storage_api, action.storage_local_directory, htmlBytes);

                    //浏览器执行配置的greatzee_has_next_page函数
                    ticket = Guid.NewGuid().ToString();
                    script = "ScriptBrige.callHasNextPage(greatzee_has_next_page().toString(),'" + ticket + "');\r\n";   //执行greatzee_has_next_page函数
                    this.browser.ExecuteScriptAsync(script);
                    this.scriptBrige.WaitTicket(ticket);//等待ScriptBrige.callHasNextPage执行完
                    
                    if (this.scriptBrige.HasNextPage)
                    {
                        //执行分页
                        this.Log($"正在执行[{action.name}]的下一页");
                        Thread.Sleep(this.context.ActionInterval);
                        this.browser.ExecuteScriptAsync("greatzee_goto_next_page();");
                    }
                    else
                    {
                        this.context.Searching = true;
                        if (this.context.CurrentIndex < this.context.Actions.Count - 1)
                        {
                            //执行下一个动作
                            this.context.CurrentIndex++;
                            if (this.context.CurrentIndex < this.context.Actions.Count)
                            {
                                Thread.Sleep(this.context.ActionInterval);
                                this.browser.Load(this.context.Actions[this.context.CurrentIndex].search_page_url);
                            }
                        }
                        else
                        {
                            //回到第一个action重新执行
                            if (this.context.ExecuteInterval >= 0)
                            {
                                this.Log("所有动作都已执行完，休眠中");
                                Thread.Sleep(this.context.ExecuteInterval);
                                this.context.CurrentIndex = 0;
                                this.browser.Load(this.context.Actions[0].search_page_url);
                            }
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="text"></param>
        private void Log(string text)
        {
            this.lbxLog.BeginInvoke(new Action(() =>
            {
                this.lbxLog.Items.Add(DateTime.Now.ToString("MM-dd HH:mm:ss ") + text);
            }));
        }
    }

    /// <summary>
    /// cefsharp访问cookie
    /// </summary>
    public class CookieVisitor : ICookieVisitor
    {
        private string cookieString = "";//domain___name|||value$$$domain^name|||value
        public Dictionary<string, string> Cookies
        {
            get
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                string[] cookieArray = this.cookieString.Split(new string[] { "$$$" }, StringSplitOptions.None);
                foreach (string item in cookieArray)
                {
                    string[] itemArray = item.Split(new string[] { "|||" }, StringSplitOptions.None);
                    if (itemArray != null && itemArray.Length == 2)
                    {
                        string cookieName = itemArray[0];
                        string cookieValue = itemArray[1];
                        if (dic.ContainsKey(cookieName))
                        {
                            dic[cookieName] = cookieValue;
                        }
                        else
                        {
                            dic.Add(cookieName, cookieValue);
                        }
                    }
                }
                return dic;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool Visit(CefSharp.Cookie cookie, int count, int total, ref bool deleteCookie)
        {
            deleteCookie = false;
            string key = cookie.Domain.TrimStart('.') + "___" + cookie.Name;
            string value = cookie.Value;
            if (!string.IsNullOrEmpty(this.cookieString))
            {
                this.cookieString += "$$$";
            }
            this.cookieString += key + "|||" + value;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string[] cookieArray = this.cookieString.Split(new string[] { "$$$" }, StringSplitOptions.None);
            foreach (string item in cookieArray)
            {
                string[] itemArray = item.Split(new string[] { "|||" }, StringSplitOptions.None);
                string cookieName = itemArray[0];
                string cookieValue = itemArray[1];
                if (dic.ContainsKey(cookieName))
                {
                    dic[cookieName] = cookieValue;
                }
                else
                {
                    dic.Add(cookieName, cookieValue);
                }
            }
            string temp = "";
            foreach (var item in dic)
            {
                temp += item.Key + "|||" + item.Value + "$$$";
            }
            if (temp.Length > 0)
            {
                temp = temp.Remove(temp.Length - 3);
            }
            this.cookieString = temp;
            return true;
        }
    }
    
}
