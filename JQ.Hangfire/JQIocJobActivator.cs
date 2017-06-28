using Hangfire;
using JQ.Container;
using System;

namespace JQ.Hangfire
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：JQJobActivator.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/27 17:23:00
    /// </summary>
    public class JQIocJobActivator : JobActivator
    {
        private readonly IObjectContainer _iocResolver;

        public JQIocJobActivator(IObjectContainer iocResolver)
        {
            if (iocResolver == null)
            {
                throw new ArgumentNullException(nameof(iocResolver));
            }
            _iocResolver = iocResolver;
        }

        public override object ActivateJob(Type jobType)
        {
            return _iocResolver.Resolve(jobType);
        }

        public override JobActivatorScope BeginScope(JobActivatorContext context)
        {
            return new JQIocJobActivatorScope(_iocResolver);
        }

        private class JQIocJobActivatorScope : JobActivatorScope
        {
            private readonly IObjectContainer _lifetimeScope;

            public JQIocJobActivatorScope(IObjectContainer lifetimeScope)
            {
                _lifetimeScope = lifetimeScope;
            }

            public override object Resolve(Type type)
            {
                return _lifetimeScope.Resolve(type);
            }

            public override void DisposeScope()
            {
            }
        }
    }
}