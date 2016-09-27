using System;
using System.Xml.Serialization;

namespace DotNet.Framework.WinXin.Core
{
    [Serializable]
    [XmlRoot("xml")]
    public class WinXinMessage
    {
        /// <summary>
        /// 开发者微信号 
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID） 
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 消息类型 [text/image/voice/video/location/link/event]
        /// </summary>
        public string MsgType { get; set; }
    }
}
