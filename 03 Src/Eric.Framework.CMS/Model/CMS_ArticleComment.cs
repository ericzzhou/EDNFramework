using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric.Framework.CMS.Model
{
    /// <summary>
    /// CMS_ArticleComment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CMS_ArticleComment
    {
        public CMS_ArticleComment()
        { }
        #region Model
        private int _id;
        private int _articleid;
        private string _title;
        private string _body;
        private DateTime _createtime = DateTime.Now;
        private int _userid = 0;
        private string _username = "匿名";
        private string _useremail;
        private string _userip;
        private string _Img;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ArticleID
        {
            set { _articleid = value; }
            get { return _articleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Body
        {
            set { _body = value; }
            get { return _body; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
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
        public string UserEmail
        {
            set { _useremail = value; }
            get { return _useremail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserIP
        {
            set { _userip = value; }
            get { return _userip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Img
        {
            set { _Img = value; }
            get { return _Img; }
        }
        #endregion Model

    }
}
