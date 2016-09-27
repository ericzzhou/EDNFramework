using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric.Framework.CMS.Model
{
    /// <summary>
    /// CMS_ArticleCategory:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CMS_ArticleCategory
    {
        public CMS_ArticleCategory()
        { }
        #region Model
        private int _id;
        private string _name;
        private int _c_index = 0;
        private bool _deleted = false;
        private bool _allowcomment = false;
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int C_Index
        {
            set { _c_index = value; }
            get { return _c_index; }
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
        public bool AllowComment
        {
            set { _allowcomment = value; }
            get { return _allowcomment; }
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
