using Topshelf;

namespace Monitor.TaskScheduling
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<Bootstrap>(s =>
                {
                    s.ConstructUsing(name => new Bootstrap());
                    s.WhenStarted(tc => tc.Install());
                    s.WhenStopped(tc => tc.UnInstall());
                });
                x.RunAsLocalSystem();

                x.SetDescription("监控任务调度服务");
                x.SetDisplayName("监控任务调度服务");
                x.SetServiceName("监控任务调度服务");
            });
        }
    }
}