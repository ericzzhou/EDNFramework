using System;

namespace Eric.Framework.Account.Model
{
    /// <summary>
    /// 类Account_Permission。
    /// </summary>
    [Serializable]
    public partial class Account_Permission
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account_Permission"/> class.
        /// </summary>
        public Account_Permission()
        { }
        #region Model
        private int _permissionid;
        private string _code;
        private string _name;
        private string _description;
        private string _url;
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
        public string Code
        {
            set { _code = value; }
            get { return _code; }
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
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        #endregion Model
    }
}
