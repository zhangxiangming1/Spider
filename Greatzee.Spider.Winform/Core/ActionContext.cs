using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greatzee.Spider.Core
{
    public class ActionContext
    {
        /// <summary>
        /// 周期间隔(毫秒)，小于0为无周期
        /// </summary>
        public int ExecuteInterval { get; set; }

        /// <summary>
        /// 动作间隔(毫秒)
        /// </summary>
        public int ActionInterval { get; set; }

        /// <summary>
        /// 当前action的下标
        /// </summary>
        public int CurrentIndex { get; set; }

        /// <summary>
        /// 是否正在执行查询
        /// </summary>
        public bool Searching { get; set; }

        /// <summary>
        /// action集合
        /// </summary>
        public List<ActionInfo> Actions { get; set; }
    }
}
