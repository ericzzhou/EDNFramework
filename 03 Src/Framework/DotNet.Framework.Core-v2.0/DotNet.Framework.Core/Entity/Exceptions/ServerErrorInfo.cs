using System;

namespace DotNet.Framework.Core.Entity.Exceptions
{
    [Serializable]
    public class ServerErrorInfo
    {
        public string ExceptionType { get; set; }
        public bool IsBizException { get; set; }
        //public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorDetail { get; set; }
        public string RequestUri { get; set; }
        public string RefererUri { get; set; }
    }
}
