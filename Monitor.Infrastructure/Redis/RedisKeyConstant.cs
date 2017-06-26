﻿namespace Monitor.Infrastructure.Redis
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RedisKeyConstant.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：redisKey的常量
    /// 创建标识：yjq 2017/6/23 10:45:52
    /// </summary>
    public partial class RedisKeyConstant
    {
        public const string REDIS_KEY_LOGINERROR_COUNT_BASE = "TryLoginCount_{0}";
    }
}