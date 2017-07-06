using Castle.DynamicProxy;
using JQ.Configurations;
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
        private readonly MethodStatistic _methodStatistic;
        public NoSqlStatisticIntercept(MethodStatistic methodStatistic)
        {
            _methodStatistic = methodStatistic;
        }
        public void Intercept(IInvocation invocation)
        {
            NoSqlStatistic noSqlStatistics = new NoSqlStatistic();
            DateTime startTime = DateTime.Now;
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                noSqlStatistics.IsSuccess = false;
                noSqlStatistics.Remark = ex.Message;
                throw;
            }
            finally
            {
                noSqlStatistics.Millisecond = (DateTime.Now - startTime).TotalMilliseconds;
                noSqlStatistics.MemberName = $"{invocation.TargetType.FullName}-{invocation.Method.Name}";
                _methodStatistic.AddNoSqlInfo(noSqlStatistics);
            }
        }
    }
}