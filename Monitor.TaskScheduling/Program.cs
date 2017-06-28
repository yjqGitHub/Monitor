using Topshelf;

namespace Monitor.TaskScheduling
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<BootStrapper>(s =>
                {
                    s.ConstructUsing(name => new BootStrapper());
                    s.WhenStarted(tc => tc.Install());
                    s.WhenStopped(tc => tc.UnInstall());
                });
                x.RunAsLocalSystem();

                x.SetDescription("监控系统任务调度服务");
                x.SetDisplayName("监控系统任务调度服务");
                x.SetServiceName("监控系统任务调度服务");
            });
        }
    }
}