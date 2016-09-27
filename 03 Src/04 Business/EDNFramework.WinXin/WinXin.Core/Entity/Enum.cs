using System.ComponentModel;

namespace DotNet.Framework.WinXin.Core.Entity
{
    enum ReqMsgType
    {
        [Description("text")]
        text,
        [Description("image")]
        image,
        [Description("voice")]
        voice,
        [Description("video")]
        video,
        [Description("location")]
        location,
        [Description("link")]
        link
    }
}
