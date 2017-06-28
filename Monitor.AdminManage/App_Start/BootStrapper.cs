using Autofac;
using Autofac.Integration.Mvc;
using JQ.Configurations;
using JQ.Container;
using JQ.Container.Autofac;
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
using System.Web.Mvc;

namespace Monitor.AdminManage.App_Start
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：BootStrapper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：BootStrapper
    /// 创建标识：yjq 2017/6/15 23:11:49
    /// </summary>
    public static class BootStrapper
    {
        /// <summary>
        /// 启动
        /// </summary>
        public static void Install()
        {
            var repositoryAssembly = Assembly.Load("Monitor.Domain.Repository");
            var domainServiceAssembly = Assembly.Load("Monitor.Domain.DomainServer");
            var userApplicationAssembly = Assembly.Load("Monitor.UserApplication");

            var builder = new ContainerBuilder();
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

            //注册控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = (ContainerManager.Current as AutofacObjectContainer).Container;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
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