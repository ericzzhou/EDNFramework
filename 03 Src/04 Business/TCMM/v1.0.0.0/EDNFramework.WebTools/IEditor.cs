using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.WebTools
{
    public interface IEditor
    {
       string CreateCss();
       string CreateJs();
       string CreateEditor(string editorID, string targetControlID);
       string CreateEditor(string editorID, string targetControlID, string allowFileManager);
    }
}
