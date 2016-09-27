
namespace DotNet.Framework.WinXin.Core.Model.Request.WXMessage
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class RequestTextMessage : RequestWinXinMessage
    {
        /// <summary>
        /// 文本消息内容 [MsgType=text]
        /// </summary>
        public string Content { get; set; }
    }
}
