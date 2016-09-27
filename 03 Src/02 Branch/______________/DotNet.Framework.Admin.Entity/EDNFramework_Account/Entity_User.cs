
using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Data;
namespace DotNet.Framework.Admin.Entity.EDNFramework_Account
{
    public class Entity_User
    {
        [DataMapping("UserID")]
        public int UserID { get; set; }

        [DataMapping("UserName")]
        public string UserName { get; set; }

        [DataMapping("Password")]
        public string Password { get; set; }

        [DataMapping("NickName")]
        public string NickName { get; set; }

        [DataMapping("TrueName")]
        public string TrueName { get; set; }

        [DataMapping("Sex")]
        public string Sex { get; set; }

        [DataMapping("Phone")]
        public string Phone { get; set; }

        [DataMapping("Email")]
        public string Email { get; set; }

        [DataMapping("EmployeeID")]
        public int? EmployeeID { get; set; }

        [DataMapping("DepartmentID")]
        public string DepartmentID { get; set; }

        [DataMapping("Activity")]
        public bool Activity { get; set; }

        [DataMapping("UserType")]
        public string UserType { get; set; }

        [DataMapping("Style")]
        public int? Style { get; set; }

        [DataMapping("User_iCreator")]
        public int? User_iCreator { get; set; }

        [DataMapping("User_dateCreate")]
        public DateTime? User_dateCreate { get; set; }

        [DataMapping("User_dateValid")]
        public DateTime? User_dateValid { get; set; }

        [DataMapping("User_dateExpire")]
        public DateTime? User_dateExpire { get; set; }

        [DataMapping("User_iApprover")]
        public int? User_iApprover { get; set; }

        [DataMapping("User_dateApprove")]
        public DateTime? User_dateApprove { get; set; }

        [DataMapping("User_iApproveState")]
        public int? User_iApproveState { get; set; }

        [DataMapping("User_cLang")]
        public string User_cLang { get; set; }

        [DataMapping("auth_token")]
        public string auth_token { get; set; }
    }

    public class Entity_UserTableData
    {
        [DataMapping("UserID")]
        public int UserID { get; set; }

        [DataMapping("UserName")]
        public string UserName { get; set; }

        [DataMapping("NickName")]
        public string NickName { get; set; }

        [DataMapping("Sex")]
        public string Sex { get; set; }

        [DataMapping("Phone")]
        public string Phone { get; set; }

        [DataMapping("Email")]
        public string Email { get; set; }

        [DataMapping("Activity")]
        public bool Activity { get; set; }

        [DataMapping("UserType")]
        public string UserType { get; set; }

        [DataMapping("UserTypeName")]
        public string UserTypeName { get; set; }

        [DataMapping("DepartmentName")]
        public string DepartmentName { get; set; }

        [DataMapping("DepartmentID")]
        public string DepartmentID { get; set; }
        

    }

    public class Entity_RoleMembers {
        [DataMapping("UserID")]
        public int UserID { get; set; }

        [DataMapping("UserName")]
        public string UserName { get; set; }

        [DataMapping("NickName")]
        public string NickName { get; set; }

        [DataMapping("Sex")]
        public string Sex { get; set; }

        [DataMapping("Activity")]
        public bool Activity { get; set; }
    }
    public class Entity_ChangePass
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Password_new { get; set; }
        public string Password_new2 { get; set; }
    }
}
