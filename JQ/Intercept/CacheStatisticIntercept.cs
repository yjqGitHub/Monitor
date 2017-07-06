using Castle.DynamicProxy;
using JQ.Configurations;
using JQ.Statistics;
using System;

namespace JQ.Intercept
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：CacheStatisticIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：CacheStatisticIntercept
    /// 创建标识：yjq 2017/7/6 22:53:38
    /// </summary>
    public class CacheStatisticIntercept : IInterceptor
    {
        private readonly MethodStatistic _methodStatistic;
        public CacheStatisticIntercept(MethodStatistic methodStatistic)
        {
            _methodStatistic = methodStatistic;
        }

        public void Intercept(IInvocation invocation)
        {
            CacheStatistic cacheStatistics = new CacheStatistic();
            DateTime startTime = DateTime.Now;
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                cacheStatistics.IsSuccess = false;
                cacheStatistics.Remark = ex.Message;
                throw;
            }
            finally
            {
                cacheStatistics.Millisecond = (DateTime.Now - startTime).TotalMilliseconds;
                cacheStatistics.MemberName = $"{invocation.TargetType.FullName}-{invocation.Method.Name}";
                _methodStatistic.AddCacheInfo(cacheStatistics);
            }
        }
    }
}