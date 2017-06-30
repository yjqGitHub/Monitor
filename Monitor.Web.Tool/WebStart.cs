using Autofac;
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
using System.Reflection;

namespace Monitor.Web.Tool
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BootStrapper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/30 17:04:15
    /// </summary>
    public static class WebStart
    {
        /// <summary>
        /// 启动
        /// </summary>
        public static void Install(ContainerBuilder builder, Action<ContainerBuilder> selfRegisterAction)
        {
            var repositoryAssembly = Assembly.Load("Monitor.Domain.Repository");
            var domainServiceAssembly = Assembly.Load("Monitor.Domain.DomainServer");
            var userApplicationAssembly = Assembly.Load("Monitor.UserApplication");

            JQConfiguration.Install(
                                    domainName: "Monitor",
                                    isStartConfigWatch: true,
                                    defaultLoggerName: "Monitor.Public.*"
                                    )
                            .UseDefaultConfig(builder)
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
            selfRegisterAction?.Invoke(builder);
            ConfigWacherUtil.Install();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public static void UnInstall()
        {
            JQConfiguration.UnInstall();
        }
    }
}