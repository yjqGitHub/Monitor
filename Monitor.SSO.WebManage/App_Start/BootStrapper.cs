using Autofac;
using Autofac.Integration.Mvc;
using JQ.Container;
using JQ.Container.Autofac;
using Monitor.Web.Tool;
using System.Web.Mvc;

namespace Monitor.SSO.WebManage.App_Start
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：BootStrapper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：BootStrapper
    /// 创建标识：yjq 2017/7/1 14:25:58
    /// </summary>
    public static class BootStrapper
    {
        public static void Install()
        {
            var builder = new ContainerBuilder();
            WebStart.Install(builder, (containerBuilder, config) =>
            {
                containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
                containerBuilder.RegisterFilterProvider();
                var container = (ContainerManager.Current as AutofacObjectContainer).Container;
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            });
        }

        public static void UnInstall()
        {
            WebStart.UnInstall();
        }
    }
}