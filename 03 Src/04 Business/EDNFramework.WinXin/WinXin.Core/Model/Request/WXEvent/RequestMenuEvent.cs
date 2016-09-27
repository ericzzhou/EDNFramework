using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.WinXin.Core.Model.Request.WXEvent
{
    /// <summary>
    /// 自定义菜单事件 [Event = CLICK/VIEW  ]
    /// </summary>
    public class RequestMenuEvent : RequestWinXinEvent
    {
        /// <summary>
        /// [Event=CLICK]事件KEY值，与自定义菜单接口中KEY值对应 
        /// [Event=VIEW]点击菜单跳转链接时的事件推送 事件KEY值，设置的跳转URL 
        /// </summary>
        public string EventKey { get; set; }
    }
}
