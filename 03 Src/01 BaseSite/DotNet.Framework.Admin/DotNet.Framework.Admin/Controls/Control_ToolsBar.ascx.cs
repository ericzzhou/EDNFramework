using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.Controls
{
    public partial class Control_ToolsBar : System.Web.UI.UserControl
    {
        //public bool disable_Refresh { get; set; }
        public bool disable_Insert { get; set; }
        public bool disable_Modify { get; set; }
        public bool disable_Delete { get; set; }
        public bool disable_Detail { get; set; }
        public bool disable_Clear { get; set; }
        //public bool disable_Leave { get; set; }

        //private string _Refresh_Fun;
        private string _Insert_Fun;
        private string _Leave_Fun;
        private string _Detail_Fun;
        private string _Delete_Fun;
        private string _Modify_Fun;
        private string _Clear_Fun;
        //public string Refresh_Fun
        //{
        //    get
        //    {
        //        if (_Refresh_Fun.IsNull())
        //            return "ToolsBar_Fun_Unrealized()";
        //        return _Refresh_Fun;
        //    }
        //    set { _Refresh_Fun = value; }
        //}
        public string Insert_Fun
        {
            get
            {
                if (_Insert_Fun.IsNull())
                    return "ToolsBar_Fun_Unrealized()";
                return _Insert_Fun;
            }
            set { _Insert_Fun = value; }
        }
        public string Modify_Fun
        {
            get
            {
                if (_Modify_Fun.IsNull())
                    return "ToolsBar_Fun_Unrealized()";
                return _Modify_Fun;
            }
            set { _Modify_Fun = value; }
        }
        public string Delete_Fun
        {
            get
            {
                if (_Delete_Fun.IsNull())
                    return "ToolsBar_Fun_Unrealized()";
                return _Delete_Fun;
            }
            set { _Delete_Fun = value; }
        }
        public string Detail_Fun
        {
            get
            {
                if (_Detail_Fun.IsNull())
                    return "ToolsBar_Fun_Unrealized()";
                return _Detail_Fun;
            }
            set { _Detail_Fun = value; }
        }
        public string Leave_Fun
        {
            get
            {
                if (_Insert_Fun.IsNull())
                    return "ToolsBar_Fun_Leave()";
                return _Leave_Fun;
            }
            set { _Leave_Fun = value; }
        }
        public string Clear_Fun
        {
            get
            {
                if (_Clear_Fun.IsNull())
                    return "ToolsBar_Fun_Unrealized()";
                return _Clear_Fun;
            }
            set { _Clear_Fun = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}