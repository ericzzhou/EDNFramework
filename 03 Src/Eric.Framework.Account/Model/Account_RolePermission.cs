using System;

namespace Eric.Framework.Account.Model
{
    /// <summary>
    /// 类Account_RolePermission。
    /// </summary>
    [Serializable]
    public partial class Account_RolePermission
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account_RolePermission"/> class.
        /// </summary>
        public Account_RolePermission()
        { }
        #region Model
        private int _roleid;
        private int _permissionid;
        private int _actionID;
        /// <summary>
        /// 
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PermissionID
        {
            set { _permissionid = value; }
            get { return _permissionid; }
        }

        public int ActionID {
            set { _actionID = value; }
            get { return _actionID; }
        }
        #endregion Model
    }
}
