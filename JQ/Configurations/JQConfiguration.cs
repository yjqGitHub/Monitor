using JQ.Container;
using JQ.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace JQ.Configurations
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：JQConfiguration.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：JQConfiguration
    /// 创建标识：yjq 2017/6/10 20:26:08
    /// </summary>
    public sealed class JQConfiguration
    {
        private Dictionary<RuntimeTypeHandle, string> _serviceNameDic = new Dictionary<RuntimeTypeHandle, string>();
        private Queue<Action> _unstallActionList = new Queue<Action>();

        private JQConfiguration()
        {
        }

        /// <summary>
        /// 项目名字
        /// </summary>
        public string AppDomainName { get; set; } = "JQ";

        /// <summary>
        /// 默认的日志记录器名字
        /// </summary>
        public string DefaultLoggerName { get; set; } = "JQ.*";

        /// <summary>
        /// 验证码加密盐值
        /// </summary>
        public string ValidateCodeSalt { get; set; } = "JQ_ValidateCode";

        /// <summary>
        /// 设置验证码的cookieKey
        /// </summary>
        public string ValidateCodeCookieKey { get; set; } = "JQ_ValidateCode";

        /// <summary>
        /// 添加注册的服务名字与类型的匹配
        /// </summary>
        /// <param name="typeHandle">类型句柄</param>
        /// <param name="serviceName">服务名字</param>
        public void AddRegisterName(RuntimeTypeHandle typeHandle, string serviceName)
        {
            _serviceNameDic[typeHandle] = serviceName;
        }

        /// <summary>
        /// 根据类型句柄获取注册服务时的名字
        /// </summary>
        /// <param name="typeHandle">类型句柄</param>
        /// <returns>注册服务时的名字</returns>
        public string GetRegisterName(RuntimeTypeHandle typeHandle)
        {
            if (_serviceNameDic.ContainsKey(typeHandle))
            {
                return _serviceNameDic[typeHandle];
            }
            return string.Empty;
        }

        /// <summary>
        /// 添加停止运行时要运行的方法
        /// </summary>
        /// <param name="action"></param>
        public void AddUnstallAction(Action action)
        {
            if (action != null)
            {
                _unstallActionList.Enqueue(action);
            }
        }

        public void Unstall()
        {
            while (_unstallActionList.Count > 0)
            {
                var action = _unstallActionList.Dequeue();
                action?.Invoke();
            }
        }

        #region Register

        public JQConfiguration SetDefault<TService, TImplementer>(string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
    where TService : class
    where TImplementer : class, TService
        {
            ContainerManager.RegisterType<TService, TImplementer>(serviceName, lifeStyle);
            return this;
        }

        public JQConfiguration SetDefault<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            ContainerManager.RegisterInstance<TService, TImplementer>(instance, serviceName);
            return this;
        }

        public JQConfiguration RegisterAssemblyTypes(Assembly assemblies, Func<Type, bool> predicate = null, LifeStyle lifeStyle = LifeStyle.Transient)
        {
            ContainerManager.RegisterAssemblyTypes(assemblies, predicate, lifeStyle);
            return this;
        }

        #endregion Register

        public static JQConfiguration Instance { get; set; }

        public static JQConfiguration Install(string domainName = null, string defaultLoggerName = null, string validateCode = null, string validateCookieKey = null)
        {
            Instance = new Configurations.JQConfiguration();
            //项目名字
            domainName.IsNotNullAndNotWhiteSpaceThenExcute(() => Instance.AppDomainName = domainName);
            //默认的日志记录器名字
            defaultLoggerName.IsNotNullAndNotWhiteSpaceThenExcute(() => Instance.DefaultLoggerName = defaultLoggerName);
            //验证码加密盐值
            validateCode.IsNotNullAndNotWhiteSpaceThenExcute(() => Instance.ValidateCodeSalt = validateCode);
            //设置验证码的cookieKey
            validateCookieKey.IsNotNullAndNotWhiteSpaceThenExcute(() => Instance.ValidateCodeCookieKey = validateCookieKey);

            return Instance;
        }

        public static void UnInstall()
        {
            Instance.Unstall();
        }

        #region 解析获取

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>注册的服务类型</returns>
        public static TService Resolve<TService>() where TService : class
        {
            return ContainerManager.Resolve<TService>();
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns>注册的服务类型</returns>
        public static object Resolve(Type serviceType)
        {
            return ContainerManager.Resolve(serviceType);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="instance">服务类型默认实例</param>
        /// <returns>成功 则返回true</returns>
        public static bool TryResolve<TService>(out TService instance) where TService : class
        {
            return ContainerManager.TryResolve(out instance);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance"></param>
        /// <returns>成功 则返回true</returns>
        public static bool TryResolve(Type serviceType, out object instance)
        {
            return ContainerManager.TryResolve(serviceType, out instance);
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="typeHandle">指定类型的句柄</param>
        /// <returns>服务类型</returns>
        public static TService ResolveNamed<TService>(RuntimeTypeHandle typeHandle) where TService : class
        {
            string serviceName = Instance.GetRegisterName(typeHandle);
            return ContainerManager.ResolveNamed<TService>(serviceName);
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <param name="typeHandle">指定类型的句柄</param>
        /// <param name="serviceType">服务类型</param>
        /// <returns>服务类型</returns>
        public static object ResolveNamed(RuntimeTypeHandle typeHandle, Type serviceType)
        {
            string serviceName = Instance.GetRegisterName(typeHandle);
            return ContainerManager.ResolveNamed(serviceName, serviceType);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <param name="typeHandle">指定类型的句柄</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance">默认实例</param>
        /// <returns>成功 则返回true</returns>
        public static bool TryResolveNamed(RuntimeTypeHandle typeHandle, Type serviceType, out object instance)
        {
            string serviceName = Instance.GetRegisterName(typeHandle);
            return ContainerManager.TryResolveNamed(serviceName, serviceType, out instance);
        }

        #endregion 解析获取
    }
}