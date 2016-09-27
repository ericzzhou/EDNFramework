using DotNet.Framework.DataAccess.Attribute;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Account
{
    public class Entity_Department
    {

        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("Code")]
        public string Code { get; set; }

        [DataMapping("Name")]
        public string Name { get; set; }

        [DataMapping("ShortName")]
        public string ShortName { get; set; }

        [DataMapping("ParentID")]
        public int ParentID { get; set; }

        [DataMapping("Type")]
        public string @Type { get; set; }

        [DataMapping("Manager")]
        public string Manager { get; set; }

        [DataMapping("Manager2")]
        public string Manager2 { get; set; }

        [DataMapping("Phone")]
        public string Phone { get; set; }

        [DataMapping("ExtNumber")]
        public string ExtNumber { get; set; }

        [DataMapping("Fax")]
        public string Fax { get; set; }

        [DataMapping("Status")]
        public string Status { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }
    }

    public class Entity_DepartmentForTree
    {

        [DataMapping("ID")]
        public int id { get; set; }


        [DataMapping("Name")]
        public string name { get; set; }


        [DataMapping("ParentID")]
        public int pId { get; set; }

        
    }
}
