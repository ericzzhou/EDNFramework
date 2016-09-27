using System;

namespace Eric.Framework.Account.Model
{
    /// <summary>
    /// 类Account_UserRole。
    /// </summary>
    [Serializable]
    public partial class Account_UserRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account_UserRole"/> class.
        /// </summary>
        public Account_UserRole()
        { }
        #region Model
        private int _userid;
        private int _roleid;
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        #endregion Model
    }
}
