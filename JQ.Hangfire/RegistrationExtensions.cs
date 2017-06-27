using System;
using System.Linq;
using Hangfire.Annotations;
using JQ.Configurations;

namespace JQ.Hangfire
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RegistrationExtensions.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/27 17:39:22
    /// </summary>
    public static class RegistrationExtensions
    {
        /// <summary>
        /// Share one instance of the component within the context of a single
        /// processing background job instance.
        /// </summary>
        /// <typeparam name="TLimit">Registration limit type.</typeparam>
        /// <typeparam name="TActivatorData">Activator data type.</typeparam>
        /// <typeparam name="TStyle">Registration style.</typeparam>
        /// <param name="registration">The registration to configure.</param>
        /// <returns>A registration builder allowing further configuration of the component.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="registration"/> is <see langword="null"/>.
        /// </exception>
        public static JQConfiguration InstancePerBackgroundJob([NotNull] this JQConfiguration configuration)
        {
            return configuration.InstancePerBackgroundJob(new object[] { });
        }

        /// <summary>
        /// Share one instance of the component within the context of a single
        /// processing background job instance.
        /// </summary>
        /// <typeparam name="TLimit">Registration limit type.</typeparam>
        /// <typeparam name="TActivatorData">Activator data type.</typeparam>
        /// <typeparam name="TStyle">Registration style.</typeparam>
        /// <param name="registration">The registration to configure.</param>
        /// <param name="lifetimeScopeTags">Additional tags applied for matching lifetime scopes.</param>
        /// <returns>A registration builder allowing further configuration of the component.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="registration"/> is <see langword="null"/>.
        /// </exception>
        public static JQConfiguration InstancePerBackgroundJob([NotNull]this JQConfiguration configuration,params object[] lifetimeScopeTags)
        {
            //if (configuration == null) throw new ArgumentNullException("configuration");

            //return configuration.SetDefault(tags);
            return configuration;
        }
    }
}
