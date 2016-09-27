using DotNet.Framework.WebTools.EditorImpl;

namespace DotNet.Framework.WebTools
{
    public class Editor
    {
        static IEditor editor = new KindEditor();
        public static string CreateCss()
        {
            return editor.CreateCss();
        }

        public static string CreateJs()
        {
            return editor.CreateJs();
        }

        public static string CreateEditor(string editorID, string targetControlID)
        {
            return editor.CreateEditor(editorID, targetControlID);
        }

        public static string CreateEditor(string editorID, string targetControlID, string allowFileManager)
        {
            return editor.CreateEditor(editorID, targetControlID, allowFileManager);
        }
    }
}
