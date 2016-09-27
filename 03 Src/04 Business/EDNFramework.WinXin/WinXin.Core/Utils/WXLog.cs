using System;
using System.IO;
using System.Text;
using System.Web;
namespace DotNet.Framework.WinXin.Core.Utils
{
    public class WXLog
    {
        private static bool CreateDirectory(string logPath)
        {
            try
            {
                if (!Directory.Exists(logPath))
                {
                    //创建文件夹
                    Directory.CreateDirectory(logPath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void Write(string type, string text)
        {
            var exceptionDirectory = HttpContext.Current.Server.MapPath("~/Logs/Message");
            if (CreateDirectory(exceptionDirectory))
            {
                string fileName = exceptionDirectory + "\\" + type + ".log";

                using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        StringBuilder sbr = new StringBuilder();
                        sbr.AppendFormat("{0}-------------------------------------------", DateTime.Now.ToString());
                        sbr.AppendLine();
                        sbr.AppendLine(text);
                        sbr.AppendLine();
                        sbr.AppendLine();
                        sw.Write(sbr.ToString());
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                    }
                }

            }
        }
    }
}
