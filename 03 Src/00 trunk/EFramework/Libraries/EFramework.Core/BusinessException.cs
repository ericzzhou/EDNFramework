using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EFramework.Core
{
    [Serializable]
    public class BusinessException : ApplicationException
    {
        public BusinessException() { }

        public BusinessException(string message) : base(message) { }

        public BusinessException(string message, Exception inner) : base(message, inner) { }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
