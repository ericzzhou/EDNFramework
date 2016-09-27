using DotNet.Framework.JobInterface;
using System;
using System.IO;

namespace DotNet.Framework.JobTest
{
    public class JobTest : IJob
    {
        public void Run(JobContext context)
        {
            try
            {
                string str = DateTime.Now.ToString("yyyy-MM-dd dddd") + "\n\r";
                StreamWriter sw = new StreamWriter(DateTime.Now.ToString("yyyyMMdd") + ".log", true);
                sw.WriteLine(str);
                sw.Close();//写入
            }
            catch
            { }
            

            //string str;
            //StreamReader sr = new StreamReader("txtreader.txt", false);
            //str = sr.ReadLine().ToString();
            //sr.Close();
            //this.textBox1.Text = str;///读取
        }


        public void Stop(JobContext context)
        {
            throw new NotImplementedException();
        }


        public void Pause(JobContext context)
        {
            throw new NotImplementedException();
        }

        public void Continue(JobContext context)
        {
            throw new NotImplementedException();
        }
    }
}
