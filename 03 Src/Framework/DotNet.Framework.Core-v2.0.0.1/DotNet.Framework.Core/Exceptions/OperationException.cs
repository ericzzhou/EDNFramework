using System;
using System.Runtime.Serialization;

namespace DotNet.Framework.Core.Exceptions
{
    /// <summary>
    /// 操作异常
    /// </summary>
    [Serializable]
    public class OperationException : ApplicationException
    {
        public OperationException()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public OperationException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="InnerException"></param>
        public OperationException(string message, System.Exception InnerException)
            : base(message, InnerException)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="Context"></param>
        public OperationException(SerializationInfo info, StreamingContext Context)
            : base(info, Context)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public OperationException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        public string ErrorDescription { get; set; }
    }
}
