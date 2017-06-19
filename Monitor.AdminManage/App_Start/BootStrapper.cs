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
    /// Copyright (C) 2017 yjq ��Ȩ���С�
    /// ������BootStrapper.cs
    /// �����ԣ������ࣨ�Ǿ�̬��
    /// �๦��������BootStrapper
    /// ������ʶ��yjq 2017/6/15 23:11:49
    /// </summary>
    public static class BootStrapper
    {
        /// <summary>
        /// ����
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

            //ע�������
            RegisterControllers();
            ConfigWacherUtil.Install();
        }

        /// <summary>
        /// ע�������
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterControllers()
        {
            var container = (ContainerManager.Current as AutofacObjectContainer).Container;
            //ע�������
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.Update(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        /// ֹͣ
        /// </summary>
        public static void UnInstall()
        {
            JQConfiguration.UnInstall();
        }
    }
}