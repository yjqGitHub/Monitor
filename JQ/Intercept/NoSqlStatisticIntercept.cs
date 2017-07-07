﻿using Castle.DynamicProxy;
using JQ.Statistics;
using System;

namespace JQ.Intercept
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：NoSqlStatisticIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：NoSqlStatisticIntercept
    /// 创建标识：yjq 2017/7/6 22:57:56
    /// </summary>
    public sealed class NoSqlStatisticIntercept : IInterceptor
    {
        private readonly RequestStatistic _methodStatistic;

        public NoSqlStatisticIntercept(RequestStatistic methodStatistic)
        {
            _methodStatistic = methodStatistic;
        }

        public void Intercept(IInvocation invocation)
        {
            TimeConsumerInfo timeConsumerInfo = new TimeConsumerInfo();
            DateTime startTime = DateTime.Now;
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                timeConsumerInfo.IsSuccess = false;
                timeConsumerInfo.Remark = ex.Message;
                throw;
            }
            finally
            {
                timeConsumerInfo.Millisecond = (DateTime.Now - startTime).TotalMilliseconds;
                timeConsumerInfo.MemberName = $"{invocation.TargetType.FullName}-{invocation.Method.Name}";
                timeConsumerInfo.ComsumerType = TimeConsumerType.NoSql;
                _methodStatistic.AddConsumerInfo(timeConsumerInfo);
            }
        }
    }
}