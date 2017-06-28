using Hangfire;
using Hangfire.Annotations;
using JQ.Container;
using System;

namespace JQ.Hangfire
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RegistrationExtensions.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/27 17:39:22
    /// </summary>
    public static class GlobalConfigurationExtensions
    {
        public static IGlobalConfiguration<JQIocJobActivator> UseAutofacActivator(
            [NotNull] this IGlobalConfiguration configuration,
            [NotNull] IObjectContainer lifetimeScope, bool useTaggedLifetimeScope = true)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (lifetimeScope == null) throw new ArgumentNullException(nameof(lifetimeScope));

            return configuration.UseActivator(new JQIocJobActivator(lifetimeScope));
        }
    }
}