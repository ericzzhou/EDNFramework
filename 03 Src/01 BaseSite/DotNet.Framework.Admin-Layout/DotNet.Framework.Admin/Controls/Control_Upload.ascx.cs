using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.Controls
{
    public partial class Control_Upload : System.Web.UI.UserControl
    {
        private string _fileId = "file_upload";
        private string _btnId = "btn_upload";
        
        /// <summary>
        /// 上传空间file的id,默认是 file_upload，如果一个页面存在多个此自定义控件，需指定 fileId
        /// </summary>
        public string fileId
        {
            get { return _fileId; }
            set { _fileId = value; }
        }

        /// <summary>
        /// 上传空间按钮的id,默认是 btn_upload，如果一个页面存在多个此自定义控件，需指定 button id
        /// </summary>
        public string btnId
        {
            get { return _btnId; }
            set { _btnId = value; }
        }

        /// <summary>
        /// 回写结果的容器ID
        /// </summary>
        public string ResultTo { get; set; }
        public string ResultImg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}