using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Greatzee.Spider.Core
{
    /// <summary>
    /// 网页javascript与后台c#方法的桥梁
    /// </summary>
    public class ScriptBrige
    {
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// 票据
        /// </summary>
        private string Ticket { get; set; }

        /// <summary>
        /// 等待凭据传回
        /// </summary>
        /// <param name="ticket"></param>
        public void WaitTicket(string ticket)
        {
            while (!ticket.Equals(this.Ticket))
            {
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 给网页javascript调用，告知后台是否还有下一页
        /// </summary>
        /// <param name="input"></param>
        /// <param name="ticket"></param>
        public void callHasNextPage(string input, string ticket)
        {
            this.Ticket = ticket;
            if ("false".Equals(input, StringComparison.CurrentCultureIgnoreCase) || "undefined".Equals(input, StringComparison.CurrentCultureIgnoreCase) || "0" == input || string.IsNullOrEmpty(input))
            {
                this.HasNextPage = false;
            }
            else
            {
                this.HasNextPage = true;
            }
        }

        /// <summary>
        /// 给网页的javascript调用，将$OPTION$对象传递给后台
        /// </summary>
        /// <param name="json"></param>
        /// <param name="guid"></param>
        public void callRegisterParameter(string json, string guid)
        {
            this.Ticket = guid;
            if ("null".Equals(json, StringComparison.CurrentCultureIgnoreCase) || "undefined".Equals(json, StringComparison.CurrentCultureIgnoreCase) || string.IsNullOrEmpty(json))
            {
                this.Parameters = "";
            }
            else
            {
                this.Parameters = json;
            }
        }
    }
}
