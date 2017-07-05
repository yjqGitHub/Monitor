using JQ.Utils;

namespace JQ.Redis
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RedisBaseRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Redis缓存访问基础类
    /// 创建标识：yjq 2017/7/5 16:40:26
    /// </summary>
    public class RedisBaseRepository
    {
        private readonly IRedisDatabaseProvider _databaseProvider;
        private readonly RedisCacheOption _cacheOption;
        private IRedisClient _clien;

        public RedisBaseRepository(IRedisDatabaseProvider databaseProvider, RedisCacheOption cacheOption)
        {
            EnsureUtil.NotNull(databaseProvider, "IRedisDatabaseProvider");
            EnsureUtil.NotNull(cacheOption, "RedisCacheOption");
            _databaseProvider = databaseProvider;
            _cacheOption = cacheOption;
        }

        /// <summary>
        /// 配置信息
        /// </summary>
        protected RedisCacheOption CacheOption
        {
            get
            {
                return _cacheOption;
            }
        }

        /// <summary>
        /// Redis实例
        /// </summary>
        public IRedisClient RedisClient
        {
            get
            {
                return _clien ?? (_clien = _databaseProvider.CreateClient(_cacheOption));
            }
        }
    }
}