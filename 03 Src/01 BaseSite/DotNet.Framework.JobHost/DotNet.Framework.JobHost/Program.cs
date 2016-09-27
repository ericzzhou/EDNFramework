using System.ServiceProcess;

namespace DotNet.Framework.JobHost
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new JobService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
