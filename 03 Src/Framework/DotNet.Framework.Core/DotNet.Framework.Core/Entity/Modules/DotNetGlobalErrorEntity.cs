using System;

namespace DotNet.Framework.Core.Entity.Modules
{
    [Serializable]
    public class DotNetGlobalErrorEntity
    {
        public string Type { get; set; }
        public bool IsBizException { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }

    }
}
