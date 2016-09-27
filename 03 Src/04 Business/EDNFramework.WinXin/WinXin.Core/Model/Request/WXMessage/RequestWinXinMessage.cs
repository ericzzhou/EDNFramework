
namespace DotNet.Framework.WinXin.Core.Model.Request.WXMessage
{
    /// <summary>
    /// 微信消息基类
    /// </summary>
    public class RequestWinXinMessage : WinXinMessage
    {
        /// <summary>
        /// 消息id，64位整型 
        /// </summary>
        public string MsgId { get; set; }
    }


}
