using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Greatzee.Spider.Core
{
    public class ActionLoad
    {
        public static ActionContext CreateContext(string path)
        {
            ActionContext context = new ActionContext();
            context.Actions = new List<ActionInfo>();
            context.Searching = true;
            context.CurrentIndex = 0;
            context.ExecuteInterval = -1;
            context.ActionInterval = 0;
            
            XmlDocument actionDoc = new XmlDocument();
            actionDoc.Load(Path.Combine(path, "action.xml"));
            XmlNode execute_interval = actionDoc.SelectSingleNode("config/execute_interval");
            if (execute_interval != null && !string.IsNullOrEmpty(execute_interval.InnerText))
            {
                context.ExecuteInterval = int.Parse(execute_interval.InnerText);
            }
            
            XmlNode action_interval = actionDoc.SelectSingleNode("config/action_interval");
            if (action_interval != null&&!string.IsNullOrEmpty(action_interval.InnerText))
            {
                context.ActionInterval = int.Parse(action_interval.InnerText);
            }

            XmlNodeList actionNodes = actionDoc.SelectNodes("config/actions/file_name");
            List<FileInfo> files = new List<FileInfo>();
            foreach (XmlNode node in actionNodes)
            {
                FileInfo f = new FileInfo(Path.Combine(path, node.InnerXml));
                files.Add(f);
            }
            
            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fi.FullName);
                    XmlAttribute name = doc.SelectSingleNode("action").Attributes["name"];
                    XmlNode charset = doc.SelectSingleNode("action/charset");
                    XmlNode search_page_url = doc.SelectSingleNode("action/search_page_url");
                    XmlNode result_page_url_regex = doc.SelectSingleNode("action/result_page_url_regex");
                    XmlNode storage_api = doc.SelectSingleNode("action/storage_api");
                    XmlNode storage_socket = doc.SelectSingleNode("action/storage_socket");
                    XmlNode storage_local_directory = doc.SelectSingleNode("action/storage_local_directory");
                    XmlNodeList scripts = doc.SelectNodes("action/script");

                    ActionInfo action = new ActionInfo();
                    action.name = name == null ? "" : name.InnerText;
                    action.charset = charset == null ? "utf-8" : charset.InnerText;
                    action.search_page_url = search_page_url == null ? "" : search_page_url.InnerText;
                    action.result_page_url_regex = result_page_url_regex == null ? "" : result_page_url_regex.InnerText;
                    action.storage_api = storage_api == null ? "" : storage_api.InnerText;
                    action.storage_socket = storage_socket == null ? "" : storage_socket.InnerText;
                    action.storage_local_directory = storage_local_directory == null ? "" : storage_local_directory.InnerText;

                    if (scripts != null)
                    {
                        foreach (XmlNode item in scripts)
                        {
                            if ("greatzee_register_parameter".Equals(item.Attributes["name"].Value))
                            {
                                action.greatzee_register_parameter = item.InnerText;
                            }
                            if ("greatzee_execute_search".Equals(item.Attributes["name"].Value))
                            {
                                action.greatzee_execute_search = item.InnerText;
                            }
                            if ("greatzee_has_next_page".Equals(item.Attributes["name"].Value))
                            {
                                action.greatzee_has_next_page = item.InnerText;
                            }
                            if ("greatzee_goto_next_page".Equals(item.Attributes["name"].Value))
                            {
                                action.greatzee_goto_next_page = item.InnerText;
                            }
                        }
                    }
                    context.Actions.Add(action);
                }
            }
            return context;
        }

        public static string GetJavaScript(ActionInfo action)
        {
            string script = action.greatzee_register_parameter + "\r\n";                
            script += "var $RegisterParameter= greatzee_register_parameter();\r\n";     //执行greatzee_register_parameter函数，将结果返回给$RegisterParameter对象
            script += action.greatzee_execute_search + "\r\n" ;
            script += action.greatzee_has_next_page + "\r\n";
            script += action.greatzee_goto_next_page + "\r\n";
            return script;
        }
    }
}
