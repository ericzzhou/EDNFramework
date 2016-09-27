using EFramework.Core.Logger;
using EFramewrok.Utils.Helper;
using System;
using System.IO;
using System.Text;

namespace EFramework.LogStrategy.DotNet
{
    public class LogStrategy : ILog
    {
        private static object _locker = new object();//锁对象

        public LogStrategy()
        { 
        }
        public void Wirte(string log)
        {
            WriteLogFile(log);
        }

        public void Wirte(Exception ex)
        {
            StringBuilder sbr = new StringBuilder();
            if (ex != null)
            {
                sbr.AppendLine(ex.Message);
                sbr.AppendLine(ex.Source);
                sbr.AppendLine(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    sbr.AppendLine(ex.InnerException.Message);
                    sbr.AppendLine(ex.InnerException.Source);
                    sbr.AppendLine(ex.InnerException.StackTrace);
                }
            }
            WriteLogFile(sbr.ToString());
        }

        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input">输入内容</param>
        public static void WriteLogFile(string input)
        {
            lock (_locker)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    string fileName = IOHelper.GetMapPath("/App_Data/ExLogs/") + DateTime.Now.ToString("yyyyMMdd") + ".log";

                    FileInfo fileInfo = new FileInfo(fileName);
                    if (!fileInfo.Directory.Exists)
                    {
                        fileInfo.Directory.Create();
                    }
                    if (!fileInfo.Exists)
                    {
                        fileInfo.Create().Close();
                    }
                    else if (fileInfo.Length > 2048)
                    {
                        fileInfo.Delete();
                    }

                    fs = fileInfo.OpenWrite();
                    sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.Write("Log Entry : ");
                    sw.Write("{0}", DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    sw.Write(Environment.NewLine);
                    sw.Write(input);
                    sw.Write(Environment.NewLine);
                    sw.Write("------------------------------------");
                    sw.Write(Environment.NewLine);
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Flush();
                        sw.Close();
                    }
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
        }



    }
}
