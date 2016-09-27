using System;

namespace EFramework.Entities.Domain.Account
{
    /// <summary>
    /// 用户列表 entity
    /// </summary>
    [Serializable]
    public class EF_Account_UserInfoEntity
    {
        public Int32 UserID { get; set; }

        public String UserName { get; set; }

        public String NickName { get; set; }

        public String TrueName { get; set; }

        public String Sex { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        public Boolean Activity { get; set; }

        public String UserType { get; set; }

        public string RoleName { get; set; }

    }
}
