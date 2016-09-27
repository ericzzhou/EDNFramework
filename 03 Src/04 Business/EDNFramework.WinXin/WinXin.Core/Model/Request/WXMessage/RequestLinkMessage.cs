
namespace DotNet.Framework.WinXin.Core.Model.Request.WXMessage
{
    /// <summary>
    /// 链接消息
    /// </summary>
    public class RequestLinkMessage : RequestWinXinMessage
    {
        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 消息描述 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 消息链接 
        /// </summary>
        public string Url { get; set; }
    }
}
