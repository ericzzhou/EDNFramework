
namespace DotNet.Framework.WinXin.Core.Model.Request.WXMessage
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class RequestImageMessage : RequestWinXinMessage
    {
        #region 图片消息
        /// <summary>
        /// 图片链接  [MsgType=image]
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。 
        /// </summary>
        public string MediaId { get; set; }
        #endregion
    }
}
