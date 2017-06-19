using Autofac;
using Autofac.Integration.Mvc;
using JQ.Configurations;
using JQ.Container;
using JQ.Container.Autofac;
using JQ.Intercept;
using JQ.MongoDb;
using JQ.MQ.RabbitMQ;
using JQ.Utils;
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

            JQConfiguration.Install(
                domainName: "Monitor",
                validateCodeSalt: "Monitor.ValidateCode",
                isStartConfigWatch: true,
                defaultLoggerName: "Monitor.Public.*",
                validateCookieKey: "Monitor.ValidateCode"
                )
                .UseDefaultConfig()
                .UseMongoDb()
                .UseRabbitMQ()
                .RegisterAssemblyTypes(repositoryAssembly, m => m.Namespace != null && m.Name.EndsWith("Repository"), lifeStyle: LifeStyle.PerLifetimeScope)
                .RegisterAssemblyTypes(domainServiceAssembly, m => m.Namespace != null && m.Name.EndsWith("DomainServer"), lifeStyle: LifeStyle.PerLifetimeScope)
                .RegisterAssemblyTypes(userApplicationAssembly, typeof(BusinessDealIntercept), m => m.Namespace != null && m.Name.EndsWith("Application"), lifeStyle: LifeStyle.PerLifetimeScope)
                ;

            //注册控制器
            RegisterControllers();
            ConfigWacherUtil.Install();
        }

        /// <summary>
        /// 注册控制器
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterControllers()
        {
            var container = (ContainerManager.Current as AutofacObjectContainer).Container;
            //注册控制器
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.Update(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
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