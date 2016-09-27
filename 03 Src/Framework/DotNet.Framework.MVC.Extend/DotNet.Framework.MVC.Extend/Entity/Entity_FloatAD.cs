using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.MVC.Extend.Entity
{
    [Serializable]
    public class Entity_FloatAD
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("Name")]
        public String Name { get; set; }

        [DataMapping("Left_Width")]
        public Int32 Left_Width { get; set; }

        [DataMapping("Left_Height")]
        public Int32 Left_Height { get; set; }

        [DataMapping("Left_left")]
        public Int32 Left_left { get; set; }

        [DataMapping("Left_top")]
        public Int32 Left_top { get; set; }

        [DataMapping("Left_Body")]
        public String Left_Body { get; set; }

        [DataMapping("Left_Enable")]
        public Boolean Left_Enable { get; set; }

        [DataMapping("Right_Width")]
        public Int32 Right_Width { get; set; }

        [DataMapping("Right_Height")]
        public Int32 Right_Height { get; set; }

        [DataMapping("Right_right")]
        public Int32 Right_right { get; set; }

        [DataMapping("Right_top")]
        public Int32 Right_top { get; set; }

        [DataMapping("Right_Body")]
        public String Right_Body { get; set; }

        [DataMapping("Right_Enable")]
        public Boolean Right_Enable { get; set; }
    }
}
