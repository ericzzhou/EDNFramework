using DotNet.Framework.JobHost.Entities;
using DotNet.Framework.JobInterface;
using System.ServiceProcess;

namespace DotNet.Framework.JobHost
{
    public class JobService : ServiceBase
    {
        private readonly IJob job;
        private JobSettingEntity jobSetting;

        public JobService()
        {
            job = JobHelper.GetJobInstance();
            InitService();
        }

        private void InitService()
        {
            jobSetting = JobHelper.JobSetting;
            this.ServiceName = JobHelper.GetJobName();
            this.CanStop = true;
            this.CanShutdown = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }
        
        protected override void OnStart(string[] args)
        {
            job.Run(JobHelper.GetJobContext());
        }

        protected override void OnStop()
        {
            job.Stop(JobHelper.GetJobContext());
        }

        protected override void OnPause()
        {
            job.Pause(JobHelper.GetJobContext());
        }
        protected override void OnContinue()
        {
            job.Continue(JobHelper.GetJobContext());
        }
    }
}
