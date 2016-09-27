using System;
using System.Runtime.Serialization;

namespace DotNet.Framework.Core.Exceptions
{
    public class ServiceException : ApplicationException
    {
        public ServiceException()
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ServiceException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="InnerException"></param>
        public ServiceException(string message, System.Exception InnerException)
            : base(message, InnerException)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="Context"></param>
        public ServiceException(SerializationInfo info, StreamingContext Context)
            : base(info, Context)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public ServiceException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        public string ErrorDescription { get; set; }


        public bool IsBizException { get; set; }

        public string ErrorDetail { get; set; }
    }
}
