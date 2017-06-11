using Autofac;
using JQ.Configurations;

namespace JQ.Container.Autofac
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AutofacConfigurationExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：AutofacConfigurationExtension
    /// 创建标识：yjq 2017/6/11 17:54:58
    /// </summary>
    public static class AutofacConfigurationExtension
    {
        #region 使用autofac为依赖注入控件

        /// <summary>
        /// 使用autofac为依赖注入控件
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static JQConfiguration UseAutofac(this JQConfiguration configuration)
        {
            return UseAutofac(configuration, new ContainerBuilder());
        }

        /// <summary>
        /// 使用autofac为依赖注入控件
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="containerBuilder"></param>
        /// <returns></returns>
        public static JQConfiguration UseAutofac(this JQConfiguration configuration, ContainerBuilder containerBuilder)
        {
            ContainerManager.SetContainer(new AutofacObjectContainer(containerBuilder));
            return configuration;
        }

        #endregion 使用autofac为依赖注入控件
    }
}