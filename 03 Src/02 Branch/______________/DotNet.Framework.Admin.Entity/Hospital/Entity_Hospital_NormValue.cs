using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Entity.Hospital
{
    [Serializable]
    public class Entity_Hospital_NormValue
    {
        [DataMapping("NormID")]
        public int NormID { get; set; }

        [DataMapping("DepartmentID")]
        public int DepartmentID { get; set; }

        [DataMapping("Value")]
        public decimal Value { get; set; }

        [DataMapping("InDate")]
        public DateTime InDate { get; set; }

        [DataMapping("InUser")]
        public int InUser { get; set; }
    }

    public class Entity_Hospital_NormValue_Search
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("NormID")]
        public int NormID { get; set; }

        [DataMapping("NormName")]
        public string NormName { get; set; }

        [DataMapping("NormValue")]
        public string NormValue { get; set; }

        [DataMapping("DepartmentID")]
        public int DepartmentID { get; set; }

        [DataMapping("DepartmentName")]
        public string DepartmentName { get; set; }

        [DataMapping("InDate")]
        public string InDate { get; set; }

        [DataMapping("InUser")]
        public int InUser { get; set; }

        [DataMapping("InUserName")]
        public string InUserName { get; set; }
    }

    public class Entity_Hospital_SearchTime
    {
        public string Year { get; set; }
        public string Month { get; set; }
    }
}
