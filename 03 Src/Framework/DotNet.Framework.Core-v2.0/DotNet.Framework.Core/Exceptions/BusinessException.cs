using System;
using System.Runtime.Serialization;

namespace DotNet.Framework.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class BusinessException : ApplicationException
    {
        public BusinessException()
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public BusinessException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="InnerException"></param>
        public BusinessException(string message, System.Exception InnerException)
            : base(message, InnerException)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="Context"></param>
        public BusinessException(SerializationInfo info, StreamingContext Context)
            : base(info, Context)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public BusinessException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        public string ErrorDescription { get; set; }
    }
}
