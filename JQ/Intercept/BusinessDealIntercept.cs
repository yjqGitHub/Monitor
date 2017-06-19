using Castle.DynamicProxy;
using JQ.Result;
using JQ.Utils;
using System;

namespace JQ.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BusinessDealIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：业务处理拦截器
    /// 创建标识：yjq 2017/6/19 17:15:20
    /// </summary>
    public class BusinessDealIntercept : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (JQException ex)
            {
                invocation.ReturnValue = OperateUtil.Exception(ex);
                string message = $"{invocation.MethodInvocationTarget.Name}-{invocation.Method.Name}:{ex.Message}";
                LogUtil.Info(message);
            }
            catch (Exception ex)
            {
                invocation.ReturnValue = OperateUtil.Exception(ex);
                LogUtil.Error(ex, memberName: $"{invocation.MethodInvocationTarget.Name}-{invocation.Method.Name}");
            }
        }
    }
}