using JQ.Configurations;
using JQ.Extensions;
using JQ.Redis;
using JQ.Utils;

namespace Monitor.Infrastructure.Redis
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RedisHelper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/21 17:22:57
    /// </summary>
    public sealed class RedisHelper
    {
        private const string _REDIS_CONNECTION_KEY = "Redis.Connection";
        private const string _REDIS_DATABASEID_KEY = "Redis.DataBaseId";

        public static RedisCacheOption GetDefaultOption()
        {
            string connection = ConfigUtil.GetValue(_REDIS_CONNECTION_KEY, "RedisHelper-GetDefaultOption");
            int databaseId = ConfigUtil.GetValue(_REDIS_DATABASEID_KEY, "RedisHelper-GetDefaultOption").ToSafeInt32(-1);
            return new RedisCacheOption
            {
                ConnectionString = connection,
                DatabaseId = databaseId,
                Prefix = "Monitor"
            };
        }

        /// <summary>
        /// 获取默认客户端
        /// </summary>
        /// <returns></returns>
        public static IRedisClient GetClient()
        {
            return JQConfiguration.Resolve<IRedisDatabaseProvider>().CreateClient(GetDefaultOption());
        }
    }
}