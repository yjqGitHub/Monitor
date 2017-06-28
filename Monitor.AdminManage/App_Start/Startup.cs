using Hangfire;
using Microsoft.Owin;
using Owin;
using System.Configuration;

[assembly: OwinStartup(typeof(Monitor.AdminManage.App_Start.Startup))]

namespace Monitor.AdminManage.App_Start
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：Startup.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Startup
    /// 创建标识：yjq 2017/6/27 16:01:50
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Hangfire.Server"];
            if (connectionString != null)
            {
                GlobalConfiguration.Configuration
               .UseSqlServerStorage(connectionString.ToString());

                app.UseHangfireDashboard();
                app.UseHangfireServer();
            }
        }
    }
}