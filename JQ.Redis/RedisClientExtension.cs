﻿using System;
using System.Threading.Tasks;

namespace JQ.Redis
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RedisClientExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：redis实例接口扩展类
    /// 创建标识：yjq 2017/6/21 11:10:17
    /// </summary>
    public static class RedisClientExtension
    {
        /// <summary>
        /// 设置值并设置过期时间
        /// </summary>
        /// <param name="redisClient">redis实例接口</param>
        /// <param name="key">键</param>
        /// <param name="expireTimeSpan">过期时间</param>
        /// <param name="setAction">设置值的方法</param>
        public static void SetAndSetExpireTime(this IRedisClient redisClient, string key, TimeSpan expireTimeSpan, Action setAction)
        {
            setAction();
            redisClient.Expire(key, expireTimeSpan);
        }

        /// <summary>
        /// 异步设置值并设置过期时间
        /// </summary>
        /// <param name="redisClient">redis实例接口</param>
        /// <param name="key">键</param>
        /// <param name="expireTimeSpan">过期时间</param>
        /// <param name="setAction">设置值的方法</param>
        /// <returns>结果可等待</returns>
        public async static Task SetAndSetExpireTimeAsync(this IRedisClient redisClient, string key, TimeSpan expireTimeSpan, Func<Task> setAction)
        {
            await setAction();
            await redisClient.ExpireAsync(key, expireTimeSpan);
            return;
        }

        /// <summary>
        /// 设置值并设置过期时间
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="redisClient">redis实例接口</param>
        /// <param name="key">键</param>
        /// <param name="expireTimeSpan">过期时间</param>
        /// <param name="setAction">设置值的方法</param>
        /// <returns>值</returns>
        public static T SetAndSetExpireTime<T>(this IRedisClient redisClient, string key, TimeSpan expireTimeSpan, Func<T> setAction)
        {
            var result = setAction();
            redisClient.Expire(key, expireTimeSpan);
            return result;
        }

        /// <summary>
        /// 异步设置值并设置过期时间
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="redisClient">redis实例接口</param>
        /// <param name="key">键</param>
        /// <param name="expireTimeSpan">过期时间</param>
        /// <param name="setAction">设置值的方法</param>
        /// <returns>值</returns>
        public async static Task<T> SetAndSetExpireTimeAsync<T>(this IRedisClient redisClient, string key, TimeSpan expireTimeSpan, Func<Task<T>> setAction)
        {
            var result = await setAction();
            await redisClient.ExpireAsync(key, expireTimeSpan);
            return result;
        }

        /// <summary>
        /// 获取并设置过期时间
        /// </summary>
        /// <typeparam name="T">结果类型</typeparam>
        /// <param name="redisClient">redis实例接口</param>
        /// <param name="key">键</param>
        /// <param name="expireTimeSpan">过期时间</param>
        /// <param name="getAction">获取的方法</param>
        /// <returns>缓存值</returns>
        public static T GetAndSetExpireTime<T>(this IRedisClient redisClient, string key, TimeSpan expireTimeSpan, Func<T> getAction)
        {
            var result = getAction();
            redisClient.Expire(key, expireTimeSpan);
            return result;
        }

        /// <summary>
        /// 异步获取并设置过期时间
        /// </summary>
        /// <typeparam name="T">结果类型</typeparam>
        /// <param name="redisClient">redis实例接口</param>
        /// <param name="key">键</param>
        /// <param name="expireTimeSpan">过期时间</param>
        /// <param name="getAction">获取的方法</param>
        /// <returns>缓存值</returns>
        public async static Task<T> GetAndSetExpireTimeAsync<T>(this IRedisClient redisClient, string key, TimeSpan expireTimeSpan, Func<Task<T>> getAction)
        {
            var result = await getAction();
            await redisClient.ExpireAsync(key, expireTimeSpan);
            return result;
        }
    }
}