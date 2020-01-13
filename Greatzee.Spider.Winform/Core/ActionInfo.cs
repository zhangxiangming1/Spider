using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greatzee.Spider.Core
{
    /// <summary>
    /// 爬虫动作的信息
    /// </summary>
    public class ActionInfo
    {
        /// <summary>
        /// 动作的名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 网页使用的编码格式
        /// </summary>
        public string charset { get; set; }

        /// <summary>
        /// 引导爬虫进入查询页面
        /// </summary>
        public string search_page_url { get; set; }

        /// <summary>
        /// 用于拦截结果页面url的正则表达式
        /// </summary>
        public string result_page_url_regex { get; set; }
       
        /// <summary>
        /// 存储结果页面的webapi地址
        /// </summary>
        public string storage_api { get; set; }

        /// <summary>
        /// 存储结果的socket地址(ip:port)
        /// </summary>
        public string storage_socket { get; set; }

        /// <summary>
        /// 在本地磁盘保存结果页面时的基路径
        /// </summary>
        public string storage_local_directory { get; set; }

        /// <summary>
        /// 获取键值对的函数
        /// </summary>
        public string greatzee_register_parameter { get; set; }

        /// <summary>
        /// 在查询页面执行查询的函数
        /// </summary>
        public string greatzee_execute_search { get; set; }

        /// <summary>
        /// 在结果页面返回“是否有下一页”的函数
        /// </summary>
        public string greatzee_has_next_page { get; set; }

        /// <summary>
        /// 在结果页面跳转到下一页的函数
        /// </summary>
        public string greatzee_goto_next_page { get; set; }
    }
}
