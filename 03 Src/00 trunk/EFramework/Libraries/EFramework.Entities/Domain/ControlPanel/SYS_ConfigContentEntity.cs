using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EFramework.Entities.Domain.ControlPanel
{
    [Serializable]
    public class SYS_ConfigContentEntity
    {
        public Int32 ID { get; set; }

        public String Keyname { get; set; }

        public String Value { get; set; }

        public Int32 KeyType { get; set; }

        public String Description { get; set; }

    }
}
