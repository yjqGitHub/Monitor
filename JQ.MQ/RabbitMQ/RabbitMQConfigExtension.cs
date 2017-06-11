using JQ.Configurations;

namespace JQ.MQ.RabbitMQ
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：RabbitMQConfigExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：RabbitMQConfigExtension
    /// 创建标识：yjq 2017/6/11 23:03:10
    /// </summary>
    public static class RabbitMQConfigExtension
    {
        public static JQConfiguration UseRabbitMq(this JQConfiguration configuration)
        {
            configuration.SetDefault<IMQFactory, RabbitMQFactory>();
            configuration.AddUnstallAction(() => RabbitMQConnectionFactory.DisposeConn());
            return configuration;
        }
    }
}