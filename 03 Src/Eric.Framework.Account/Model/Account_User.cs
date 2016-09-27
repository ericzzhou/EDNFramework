using System;

namespace Eric.Framework.Account.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class Account_User
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Account_User"/> class.
        /// </summary>
        public Account_User()
        { }
        #region Model
        private int _userid;
        private string _username;
        private string _password;
        private string _truename = "匿名";
        private string _sex;
        private DateTime? _birthday;
        private string _phone;
        private string _email;
        private string _employeeid;
        private string _departmentid;
        private bool _activity = false;
        private string _usertype;
        private DateTime _registerdate = DateTime.Now;
        private string _registerip;
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
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmployeeID
        {
            set { _employeeid = value; }
            get { return _employeeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentID
        {
            set { _departmentid = value; }
            get { return _departmentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Activity
        {
            set { _activity = value; }
            get { return _activity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegisterIP
        {
            set { _registerip = value; }
            get { return _registerip; }
        }
        #endregion
    }
}
