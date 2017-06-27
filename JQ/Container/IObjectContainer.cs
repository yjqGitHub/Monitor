using System;
using System.Reflection;

namespace JQ.Container
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IObjectContainer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：容器接口
    /// 创建标识：yjq 2017/6/11 14:31:13
    /// </summary>
    public interface IObjectContainer : IDisposable
    {
        #region 注册

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="implementationType">实例类型</param>
        /// <param name="serviceName">服务名称</param>
        /// <param name="lifeStyle">生命周期</param>
        void RegisterType(Type implementationType, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="implementationType">实例类型</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名称</param>
        /// <param name="lifeStyle">生命周期</param>
        void RegisterType(Type implementationType, Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实例类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="life">生命周期</param>
        void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实例类型</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        void RegisterType(Type serviceType, Type implementationType, Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton);

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        void RegisterType<TService, TImplementer>(string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
           where TService : class
           where TImplementer : class, TService;

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        void RegisterType<TService, TImplementer>(Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService;

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="instance">实例值</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
           where TService : class
           where TImplementer : class, TService;

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="instance">实例值</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        void RegisterInstance<TService, TImplementer>(TImplementer instance, Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
           where TService : class
           where TImplementer : class, TService;

        /// <summary>
        /// 根据程序集注册
        /// </summary>
        /// <param name="assemblies">程序集</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="lifeStyle">生命周期</param>
        void RegisterAssemblyTypes(Assembly assemblies, Func<Type, bool> predicate = null, LifeStyle lifeStyle = LifeStyle.PerLifetimeScope);

        /// <summary>
        /// 根据程序集注册
        /// </summary>
        /// <param name="assemblies">程序集</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="lifeStyle">生命周期</param>
        void RegisterAssemblyTypes(Assembly assemblies, Type[] interceptTypeList, Func<Type, bool> predicate = null, LifeStyle lifeStyle = LifeStyle.PerLifetimeScope);

        #endregion 注册

        #region 解析获取

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>注册的服务类型</returns>
        TService Resolve<TService>() where TService : class;

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns>注册的服务类型</returns>
        object Resolve(Type serviceType);

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="instance">服务类型默认实例</param>
        /// <returns>成功 则返回true</returns>
        bool TryResolve<TService>(out TService instance) where TService : class;

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance"></param>
        /// <returns>成功 则返回true</returns>
        bool TryResolve(Type serviceType, out object instance);

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="serviceName">服务名字</param>
        /// <returns>服务类型</returns>
        TService ResolveNamed<TService>(string serviceName) where TService : class;

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <param name="serviceName">服务名字</param>
        /// <param name="serviceType">服务类型</param>
        /// <returns>服务类型</returns>
        object ResolveNamed(string serviceName, Type serviceType);

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <param name="serviceName">服务名字</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance">默认实例</param>
        /// <returns>成功 则返回true</returns>
        bool TryResolveNamed(string serviceName, Type serviceType, out object instance);

        #endregion 解析获取
    }
}