using DotNet.Framework.DataAccess.Attribute;

namespace DotNet.Framework.Admin.Entity.EDNFramework_CMS
{
    public class Entity_FLinks
    {
        [DataMapping("ID")]
        public int ID { get; set; }
        [DataMapping("Name")]
        public string Name { get; set; }
        [DataMapping("ImgUrl")]
        public string ImgUrl { get; set; }
        [DataMapping("LinkUrl")]
        public string LinkUrl { get; set; }
        [DataMapping("LinkDesc")]
        public string LinkDesc { get; set; }
        [DataMapping("State")]
        public bool State { get; set; }
        [DataMapping("OrderID")]
        public int OrderID { get; set; }
        [DataMapping("ContactPerson")]
        public string ContactPerson { get; set; }
        [DataMapping("Email")]
        public string Email { get; set; }
        [DataMapping("TelPhone")]
        public string TelPhone { get; set; }
        [DataMapping("TypeID")]
        public int? TypeID { get; set; }
        [DataMapping("IsDisplay")]
        public bool IsDisplay { get; set; }
        [DataMapping("ImgWidth")]
        public int? ImgWidth { get; set; }
        [DataMapping("ImgHeight")]
        public int? ImgHeight { get; set; }
    }
}
