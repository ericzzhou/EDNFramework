
namespace DotNet.Framework.WinXin.Core.Model.Request.WXMessage
{
    /// <summary>
    /// 语音
    /// </summary>
    public class RequestVoiceMessage:RequestWinXinMessage
    {
        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。 
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 语音格式，如amr，speex等 
        /// </summary>
        public string Format { get; set; }
    }
}
