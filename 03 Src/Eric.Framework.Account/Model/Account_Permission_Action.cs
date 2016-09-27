using System;

namespace Eric.Framework.Account.Model
{
    /// <summary>
    /// 类Account_Permission_Action。
    /// </summary>
    [Serializable]
    public partial class Account_Permission_Action
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account_Permission_Action"/> class.
        /// </summary>
        public Account_Permission_Action()
        { }
        #region Model
        private int _actionid;
        private string _code;
        private int _permissionid;
        private string _name;
        /// <summary>
        /// 
        /// </summary>
        public int ActionID
        {
            set { _actionid = value; }
            get { return _actionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PermissionID
        {
            set { _permissionid = value; }
            get { return _permissionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        #endregion Model
    }
}
