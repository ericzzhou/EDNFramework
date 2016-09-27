using System;

namespace Eric.Framework.Account.Model
{
    /// <summary>
    /// 类Account_Role。
    /// </summary>
    [Serializable]
    public class Account_Role
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account_Role"/> class.
        /// </summary>
        public Account_Role()
        { }
        #region Model
        private int _roleid;
        private string _name;
        private string _description;
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        #endregion Model
    }
}
