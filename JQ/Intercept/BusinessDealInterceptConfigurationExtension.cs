using JQ.Configurations;

namespace JQ.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BusinessDealInterceptConfigurationExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/20 11:26:31
    /// </summary>
    public static class BusinessDealInterceptConfigurationExtension
    {
        public static JQConfiguration UseBusinessDealIntercept(this JQConfiguration configuration)
        {
            configuration.SetDefault(typeof(BusinessDealIntercept), lifeStyle: Container.LifeStyle.PerLifetimeScope);
            return configuration;
        }
    }
}