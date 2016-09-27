using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFramework.HttpModule.Entities
{
    [Serializable]
    public class GlobalErrorEntity
    {
        public string Type { get; set; }
        public bool IsBizException { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
    }
}
