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
    public sealed class Bootstrap
    {
        private readonly LoggerSubscribeTask loggerSubcribe;

        public Bootstrap()
        {
            loggerSubcribe = new TaskScheduling.LoggerSubscribeTask();
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

        public void UnInstall()
        {
            loggerSubcribe.Unstall();
            JQConfiguration.UnInstall();
        }
    }
}
