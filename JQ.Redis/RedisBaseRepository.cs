using JQ.Utils;
using System;

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

        /// <summary>
        /// 获取值(缓存异常时则从db获取)
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="key">key</param>
        /// <param name="cacheGetAction">缓存获取的方法</param>
        /// <param name="dbGetAction">db获取方法</param>
        /// <param name="memberName">调用方法名字</param>
        /// <returns>值</returns>
        protected T GetValue<T>(string key, Func<string, T> cacheGetAction, Func<T> dbGetAction, string memberName = null)
        {
            try
            {
                return cacheGetAction(key);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, memberName: memberName);
                return dbGetAction();
            }
        }

        /// <summary>
        /// 获取或者设置值(缓存异常时则从db获取)
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="key">key</param>
        /// <param name="cacheGetAction">缓存获取的方法</param>
        /// <param name="cacheSetAction">缓存设置的方法</param>
        /// <param name="dbGetAction">db获取方法</param>
        /// <param name="memberName">调用方法名字</param>
        /// <returns>值</returns>
        protected T GetValueWhenNotExitThenSet<T>(string key, Func<string, T> cacheGetAction, Action<string, T> cacheSetAction, Func<T> dbGetAction, string memberName = null)
        {
            try
            {
                if (RedisClient.Exists(key))
                {
                    return cacheGetAction(key);
                }
                else
                {
                    var value = dbGetAction();
                    cacheSetAction(key, value);
                    return value;
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, memberName: memberName);
                return dbGetAction();
            }
        }
    }
}