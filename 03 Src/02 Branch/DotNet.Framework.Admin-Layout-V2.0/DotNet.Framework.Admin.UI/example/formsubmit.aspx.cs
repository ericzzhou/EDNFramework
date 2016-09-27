using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.UI.example
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public bool Activity { get; set; }
        public string Role { get; set; }
        public string Photo { get; set; }
        public string Remark { get; set; }
    }
    public class Role
    {
        public string Key { get; set; }
        public string Value { get; set; }
        
    }
    public partial class formsubmit : System.Web.UI.Page
    {
        public string Json_UserModel = "{}";
        public string Json_Roles = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            Json_UserModel = DotNet.Framework.Utils.Serialization
                .ObjectJsonSerializer.Serialize<UserInfo>(GetUserModel());
            Json_Roles =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Serialize<List<Role>>(new List<Role>() { 
                 new Role(){ Key="系统管理员", Value="AA"},
                 new Role(){ Key="文章管理员", Value="BB"},
                 new Role(){ Key="产品PM", Value="CC"},
                 new Role(){ Key="注册用户", Value="DD"}
                });
        }
        public UserInfo GetUserModel()
        {
            return new UserInfo()
            {
                Id = 1,
                Activity = true,
                Name = "Eric Zhou",
                Age = 27,
                Role = "BB",
                Sex = "女",
                Photo = "/upload/eric.png",
                Remark = "一介程序员"
            };
        }

    }
}