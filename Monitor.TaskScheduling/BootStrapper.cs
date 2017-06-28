using Hangfire;
using JQ.Configurations;
using JQ.Container;
using JQ.Intercept;
using JQ.MongoDb;
using JQ.MQ.Logger;
using JQ.MQ.RabbitMQ;
using JQ.MQ.Serialization;
using JQ.Redis.StackExchangeRedis;
using JQ.Utils;
using Monitor.Infrastructure.MQ;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Monitor.TaskScheduling
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：Bootstrap.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：启动程序
    /// 创建标识：yjq 2017/6/26 12:59:38
    /// </summary>
    public sealed class BootStrapper
    {
        private readonly LoggerSubscribeTask loggerSubcribe;
        private readonly BackgroundJobServer _server;
        public BootStrapper()
        {
            loggerSubcribe = new LoggerSubscribeTask();
            _server = new BackgroundJobServer();
        }

        public void Install()
        {
            var repositoryAssembly = Assembly.Load("Monitor.Domain.Repository");
            var domainServiceAssembly = Assembly.Load("Monitor.Domain.DomainServer");
            var userApplicationAssembly = Assembly.Load("Monitor.UserApplication");

            JQConfiguration.Install(
                                    domainName: "Monitor.TaskScheduling",
                                    isStartConfigWatch: true,
                                    defaultLoggerName: "Monitor.Public.*"
                                    )
                            .UseDefaultConfig()
                            .UseMongoDb()
                            .UseMQProtobufBinarySerializer()
                            .UseMQJsonBinarySerializer()
                            .UseRabbitMQ()
                            .UseStackExchageRedis()
                            .UseMQLogger(() => MQLoggerUtil.GetMQLoggerConfig())
                            .RegisterAssemblyTypes(repositoryAssembly, m => m.Namespace != null && m.Name.EndsWith("Repository"), lifeStyle: LifeStyle.PerLifetimeScope)
                            .RegisterAssemblyTypes(domainServiceAssembly, m => m.Namespace != null && m.Name.EndsWith("DomainServer"), lifeStyle: LifeStyle.PerLifetimeScope)
                            .RegisterAssemblyTypes(userApplicationAssembly, new Type[] { typeof(BusinessDealIntercept) }, m => m.Namespace != null && m.Name.EndsWith("Application"), lifeStyle: LifeStyle.PerLifetimeScope)
                ;

            ConfigWacherUtil.Install();

            loggerSubcribe.Install();

        }

        private void StartHangFire()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Hangfire.Server"];
            if (connectionString != null)
            {
                GlobalConfiguration.Configuration.UseColouredConsoleLogProvider().UseSqlServerStorage(connectionString.ToString());
                _server.SendStop();
            }
               
        }

        public void UnInstall()
        {
            loggerSubcribe.Unstall();
            JQConfiguration.UnInstall();
        }
    }
}
