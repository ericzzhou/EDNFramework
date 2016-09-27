
namespace DotNet.Framework.WinXin.Core.Model.Request.WXEvent
{

    public class RequestWinXinEvent : WinXinMessage
    {
        /// <summary>
        /// 事件类型
        /// subscribe 用户未关注时，进行关注后的事件推送
        /// unsubscribe 
        /// SCAN 用户已关注时的事件推送
        /// LOCATION 上报地理位置事件
        /// CLICK 自定义菜单事件
        /// VIEW 点击菜单跳转链接时的事件推送 
        /// </summary>
        public string Event { get; set; }
    }
}
