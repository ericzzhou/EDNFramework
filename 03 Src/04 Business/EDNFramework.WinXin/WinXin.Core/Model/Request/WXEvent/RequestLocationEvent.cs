
namespace DotNet.Framework.WinXin.Core.Model.Request.WXEvent
{
    /// <summary>
    /// 上报地理位置事件 [Event = LOCATION  ]
    /// </summary>
    public class RequestLocationEvent : RequestWinXinEvent
    {
        /// <summary>
        /// 地理位置纬度 
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// 地理位置经度 
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// 地理位置精度 
        /// </summary>
        public string Precision { get; set; }
    }
}
