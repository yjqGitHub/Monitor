using JQ.Extensions;
using JQ.Redis;
using Monitor.ICache;
using Monitor.Infrastructure.Redis;
using Monitor.TransDto.Admin;
using System;
using System.Threading.Tasks;

namespace Monitor.Cache
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AuthorityCache.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：授权信息缓存
    /// 创建标识：yjq 2017/7/5 15:07:55
    /// </summary>
    public sealed class AuthorityCache : RedisBaseRepository, IAuthorityCache
    {
        /// <summary>
        /// 用户信息的缓存Key
        /// </summary>
        private const string _REDIS_KEY_ADMININFO = "AdminInfo";

        /// <summary>
        /// 授权Token的缓存Key
        /// </summary>
        private const string _REDIS_KEY_AUTHORITY_TOKEN = "AuthorityToken";

        /// <summary>
        /// 用户尝试登录次数的Key
        /// </summary>
        private const string _REDIS_KEY_LOGINERROR_COUNT_BASE = "TryLoginCount_{0}";

        public AuthorityCache(IRedisDatabaseProvider databaseProvider) : base(databaseProvider, RedisHelper.GetDefaultOption())
        {
        }

        /// <summary>
        /// 设置登录失败次数
        /// </summary>
        /// <param name="userName">要设置的用户名</param>
        /// <returns></returns>
        public long AddLoginFailedCount(string userName)
        {
            return RedisClient.SetAndSetExpireTime(string.Format(_REDIS_KEY_LOGINERROR_COUNT_BASE, userName), expireTimeSpan: TimeSpan.FromMinutes(1), setAction: (redisClient, key) =>
              {
                  return redisClient.StringIncrement(key);
              });
        }

        /// <summary>
        /// 异步设置登录失败次数
        /// </summary>
        /// <param name="userName">要设置的用户名</param>
        /// <returns></returns>
        public async Task<long> AddLoginFailedCountAsync(string userName)
        {
            return await RedisClient.SetAndSetExpireTimeAsync(string.Format(_REDIS_KEY_LOGINERROR_COUNT_BASE, userName),
                  expireTimeSpan: TimeSpan.FromMinutes(1),
                  setAction: async (redisClient, key) =>
              {
                  return await redisClient.StringIncrementAsync(key);
              });
        }

        /// <summary>
        /// 获取登录失败次数
        /// </summary>
        /// <param name="userName">要获取的用户名</param>
        /// <returns>失败次数</returns>
        public long GetLoginFailedCount(string userName)
        {
            return RedisClient.StringGet<long>(string.Format(RedisKeyConstant.REDIS_KEY_LOGINERROR_COUNT_BASE, userName));
        }

        /// <summary>
        /// 异步获取登录失败次数
        /// </summary>
        /// <param name="userName">要获取的用户名</param>
        /// <returns>失败次数</returns>
        public Task<long> GetLoginFailedCountAsync(string userName)
        {
            return RedisClient.StringGetAsync<long>(string.Format(RedisKeyConstant.REDIS_KEY_LOGINERROR_COUNT_BASE, userName));
        }

        /// <summary>
        /// 添加授权Token
        /// </summary>
        /// <param name="token">token值</param>
        /// <param name="adminInfo">对应用户信息</param>
        /// <returns>成功返回true</returns>
        public bool AddAuthorityToken(string token, AdminDto adminInfo)
        {
            if (token.IsNotNullAndNotWhiteSpace())
            {
                return RedisClient.HashSet(_REDIS_KEY_AUTHORITY_TOKEN, token, adminInfo);
            }
            return false;
        }

        /// <summary>
        /// 异步添加授权Token
        /// </summary>
        /// <param name="token">token值</param>
        /// <param name="adminInfo">对应用户信息</param>
        /// <returns>成功返回true</returns>
        public async Task<bool> AddAuthorityTokenAsync(string token, AdminDto adminInfo)
        {
            if (token.IsNotNullAndNotWhiteSpace())
            {
                return await RedisClient.HashSetAsync(_REDIS_KEY_AUTHORITY_TOKEN, token, adminInfo);
            }
            return false;
        }

        /// <summary>
        /// 移除授权token
        /// </summary>
        /// <param name="token">要移除的token</param>
        /// <returns>成功返回true</returns>
        public bool RemoveAuthorityToken(string token)
        {
            if (token.IsNotNullAndNotWhiteSpace())
            {
                return RedisClient.HashDelete(_REDIS_KEY_AUTHORITY_TOKEN, token);
            }
            return true;
        }

        /// <summary>
        /// 异步移除授权token
        /// </summary>
        /// <param name="token">要移除的token</param>
        /// <returns>成功返回true</returns>
        public async Task<bool> RemoveAuthorityTokenAsync(string token)
        {
            if (token.IsNotNullAndNotWhiteSpace())
            {
                return await RedisClient.HashDeleteAsync(_REDIS_KEY_AUTHORITY_TOKEN, token);
            }
            return true;
        }

        /// <summary>
        /// 判断是否存在token
        /// </summary>
        /// <param name="token">要判断的token值</param>
        /// <returns>存在返回true</returns>
        public bool IsExistToken(string token)
        {
            if (token.IsNotNullAndNotWhiteSpace())
            {
                return RedisClient.HashExists(_REDIS_KEY_AUTHORITY_TOKEN, token);
            }
            return false;
        }

        /// <summary>
        /// 异步判断是否存在token
        /// </summary>
        /// <param name="token">要判断的token值</param>
        /// <returns>存在返回true</returns>
        public async Task<bool> IsExistTokenAsync(string token)
        {
            if (token.IsNotNullAndNotWhiteSpace())
            {
                return await RedisClient.HashExistsAsync(_REDIS_KEY_AUTHORITY_TOKEN, token);
            }
            return false;
        }
    }
}