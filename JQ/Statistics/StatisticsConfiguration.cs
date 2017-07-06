using JQ.Configurations;

namespace JQ.Statistics
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：StatisticsConfiguration.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：StatisticsConfiguration
    /// 创建标识：yjq 2017/7/6 22:49:54
    /// </summary>
    public static class StatisticsConfiguration
    {
        public static JQConfiguration UseStatistics(this JQConfiguration configuration)
        {
            configuration.SetDefault(typeof(MethodStatistic), lifeStyle: Container.LifeStyle.PerLifetimeScope);
            return configuration;
        }
    }
}