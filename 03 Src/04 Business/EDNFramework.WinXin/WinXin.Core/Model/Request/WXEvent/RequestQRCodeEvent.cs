
namespace DotNet.Framework.WinXin.Core.Model.Request.WXEvent
{
    /// <summary>
    /// 扫描带参数二维码事件 
    /// [Event = subscribe] 用户未关注时，进行关注后的事件推送
    /// [Event = SCAN] 用户已关注时的事件推送
    /// </summary>
    public class RequestQRCodeEvent : RequestWinXinEvent
    {
        /// <summary>
        /// 事件KEY值，是一个32位无符号整数，即创建二维码时的二维码scene_id 
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片 
        /// </summary>
        public string Ticket { get; set; }

        
    }
}
