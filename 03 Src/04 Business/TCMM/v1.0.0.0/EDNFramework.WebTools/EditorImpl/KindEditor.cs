using DotNet.Framework.Admin.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.WebTools.EditorImpl
{
    public class KindEditor : IEditor
    {
        #region Editor
        /// <summary>
        /// 引用 editor 样式文件
        /// </summary>
        /// <returns></returns>
        public string CreateCss()
        {
            StringBuilder sbr = new StringBuilder();
            sbr.AppendFormat("<link rel=\"stylesheet\" href=\"{0}/Resource/editor/themes/default/default.css\" />", ConfigHelper.ResourcePath);
            sbr.AppendFormat("<link rel=\"stylesheet\" href=\"{0}/Resource/editor/plugins/code/prettify.css\" />", ConfigHelper.ResourcePath);
            return sbr.ToString();
        }

        /// <summary>
        /// 引用 editor js 文件
        /// </summary>
        /// <returns></returns>
        public string CreateJs()
        {
            StringBuilder sbr = new StringBuilder();
            sbr.AppendFormat("<script charset=\"utf-8\" src=\"{0}/Resource/editor/kindeditor.js\"></script>", ConfigHelper.ResourcePath);
            sbr.AppendFormat("<script charset=\"utf-8\" src=\"{0}/Resource/editor/lang/zh_CN.js\"></script>", ConfigHelper.ResourcePath);
            sbr.AppendFormat("<script charset=\"utf-8\" src=\"{0}/Resource/editor/plugins/code/prettify.js\"></script>", ConfigHelper.ResourcePath);
            return sbr.ToString();
        }
        /// <summary>
        /// 生成Editor,允许 显示文件管理器
        /// </summary>
        /// <param name="editorID">编辑器变量</param>
        /// <param name="targetControlID">目标控件ID,必须带 #</param>
        /// <returns></returns>
        public string CreateEditor(string editorID, string targetControlID)
        {
            return CreateEditor(editorID, targetControlID, "true");
        }

        /// <summary>
        /// 生成Editor
        /// </summary>
        /// <param name="editorID">编辑器变量</param>
        /// <param name="targetControlID">目标控件ID,必须带 #</param>
        /// <param name="allowFileManager">是否允许显示文件管理器，字符串 true/false</param>
        /// <returns></returns>
        public string CreateEditor(string editorID, string targetControlID, string allowFileManager)
        {
            string jsScript = string.Format(@"
var {0};
KindEditor.ready(function(K) {{
			{1} = K.create('{2}', {{
				cssPath : '{3}/Resource/editor/plugins/code/prettify.css',
				uploadJson : '{4}/Resource/editor/asp.net/upload_json.ashx',
				fileManagerJson : '{5}/Resource/editor/asp.net/file_manager_json.ashx',
				allowFileManager : {6}
			}});
			prettyPrint();
		}});
", editorID, editorID, targetControlID
 , ConfigHelper.ResourcePath
 , ConfigHelper.ResourcePath
 , ConfigHelper.ResourcePath
 , allowFileManager);

            return jsScript;
        }
        #endregion
    }
}
