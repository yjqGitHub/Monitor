using JQ.Configurations;
using JQ.Redis.Serialization;

namespace JQ.Redis.StackExchangeRedis
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：StackExchangeConfigurationExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/21 10:56:23
    /// </summary>
    public static class StackExchangeConfigurationExtension
    {
        public static JQConfiguration UseStackExchageRedis(this JQConfiguration configuration)
        {
            configuration.SetDefault<IRedisBinarySerializer, RedisJsonBinarySerializer>();
            configuration.SetDefault<IRedisDatabaseProvider, StackExchangeRedisProvider>();
            configuration.AddUnstallAction(() => ConnectionMultiplexerFactory.DisposeConn());
            return configuration;
        }
    }
}