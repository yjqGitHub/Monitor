using JQ.Configurations;
using JQ.Container;

namespace Monitor.SchedulerTasks
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：TaskConfigurationExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/29 13:49:02
    /// </summary>
    public static class TaskConfigurationExtension
    {
        /// <summary>
        /// 注册所有的监听任务
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static JQConfiguration RegisterScheduleTasks(this JQConfiguration configuration)
        {
            configuration.SetDefault<LogSubscribeTask>(lifeStyle: LifeStyle.PerLifetimeScope);
            return configuration;
        }
    }
}