using JQ.Serialization;

namespace JQ.Redis.StackExchangeRedis
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：StackExchangeRedisProvider.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：StackExchangeRedisProvider
    /// 创建标识：yjq 2017/6/21 10:50:49
    /// </summary>
    public sealed class StackExchangeRedisProvider : IRedisDatabaseProvider
    {
        private readonly IBinarySerializer _binarySerializer;

        public StackExchangeRedisProvider(IBinarySerializer binarySerializer)
        {
            _binarySerializer = binarySerializer;
        }

        /// <summary>
        /// 创建redis客户端
        /// </summary>
        /// <param name="redisCacheOption">redis配置信息</param>
        /// <returns></returns>
        public IRedisClient CreateClient(RedisCacheOption redisCacheOption)
        {
            return new StackExchangeRedisClient(redisCacheOption, _binarySerializer);
        }

        /// <summary>
        /// 创建redis客户端
        /// </summary>
        /// <param name="redisCacheOption">redis配置信息</param>
        /// <param name="serializer">序列化类</param>
        /// <returns></returns>
        public IRedisClient CreateClient(RedisCacheOption redisCacheOption, IBinarySerializer serializer)
        {
            return new StackExchangeRedisClient(redisCacheOption, serializer);
        }
    }
}