using System;
using System.Runtime.Serialization;

namespace DotNet.Framework.Core.Exceptions
{
    /// <summary>
    /// 授权异常
    /// </summary>
    [Serializable]
    public class AuthorizationException : ApplicationException
    {
        public AuthorizationException()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public AuthorizationException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="InnerException"></param>
        public AuthorizationException(string message, System.Exception InnerException)
            : base(message, InnerException)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="Context"></param>
        public AuthorizationException(SerializationInfo info, StreamingContext Context)
            : base(info, Context)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public AuthorizationException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        public string ErrorDescription { get; set; }
    }
}
