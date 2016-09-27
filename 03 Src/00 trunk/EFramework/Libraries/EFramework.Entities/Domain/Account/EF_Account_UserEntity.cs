using System;

namespace EFramework.Entities.Domain.Account
{
    /// <summary>
    /// add /edit user entity
    /// </summary>
    [Serializable]
    public class EF_Account_UserEntity
    {
        public Int32 UserID { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public String NickName { get; set; }

        public String TrueName { get; set; }

        public String Sex { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        public Int32 EmployeeID { get; set; }

        public String DepartmentID { get; set; }

        public Boolean Activity { get; set; }

        public String UserType { get; set; }

        public Int32 Style { get; set; }

        public Int32 User_iCreator { get; set; }

        public DateTime User_dateCreate { get; set; }

        public DateTime User_dateValid { get; set; }

        public DateTime User_dateExpire { get; set; }

        public Int32 User_iApprover { get; set; }

        public DateTime User_dateApprove { get; set; }

        public Int32 User_iApproveState { get; set; }

        public String User_cLang { get; set; }

        public String auth_token { get; set; }
    }
}
