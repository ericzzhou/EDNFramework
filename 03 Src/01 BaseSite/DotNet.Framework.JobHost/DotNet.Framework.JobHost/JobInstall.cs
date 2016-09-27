using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.ServiceProcess;
namespace DotNet.Framework.JobHost
{
    [RunInstaller(true)]
    public class JobInstall : Installer
    {
        private ServiceInstaller installer;
        private ServiceProcessInstaller proInstaller;

        public JobInstall()
        {
            installer = new ServiceInstaller();
            proInstaller = new ServiceProcessInstaller();
            proInstaller.Account = ServiceAccount.LocalSystem;

            installer.StartType = ServiceStartMode.Automatic;
            installer.ServiceName = JobHelper.GetJobName();
            installer.DisplayName = JobHelper.GetJobDisplayName();
            installer.Description = JobHelper.GetJobDescription();

            Installers.Add(installer);
            Installers.Add(proInstaller);
        }
    }
}
