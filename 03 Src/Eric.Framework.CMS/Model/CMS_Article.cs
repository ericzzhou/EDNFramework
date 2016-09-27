using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric.Framework.CMS.Model
{
    /// <summary>
    /// CMS_Article:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CMS_Article
    {
        public CMS_Article()
        { }
        #region Model
        private int _id;
        private string _code;
        private string _keyword;
        private string _description;
        private string _title;
        private string _body;
        private string _tag;
        private bool _deleted = false;
        private int? _categoryid;
        private bool _allowcomment = true;
        private DateTime _createtime = DateTime.Now;
        private int _authorid = 0;
        private string _authorname;
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
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Keyword
        {
            set { _keyword = value; }
            get { return _keyword; }
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
        public string Tag
        {
            set { _tag = value; }
            get { return _tag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Deleted
        {
            set { _deleted = value; }
            get { return _deleted; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CategoryID
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool AllowComment
        {
            set { _allowcomment = value; }
            get { return _allowcomment; }
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
        public int AuthorID
        {
            set { _authorid = value; }
            get { return _authorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuthorName
        {
            set { _authorname = value; }
            get { return _authorname; }
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
