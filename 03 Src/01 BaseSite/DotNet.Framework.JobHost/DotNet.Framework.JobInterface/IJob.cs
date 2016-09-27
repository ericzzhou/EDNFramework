
namespace DotNet.Framework.JobInterface
{
    public interface IJob
    {
        void Run(JobContext context);
        void Stop(JobContext context);
        void Pause(JobContext context);
        void Continue(JobContext context);
    }
}
