using JQ.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JQ.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：PropertyUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：属性工具类
    /// 创建标识：yjq 2017/6/20 16:49:31
    /// </summary>
    public static class PropertyUtil
    {
        /// <summary>
        /// 属性缓存
        /// </summary>
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, List<PropertyInfo>> _propertyCache = new ConcurrentDictionary<RuntimeTypeHandle, List<PropertyInfo>>();

        /// <summary>
        /// 获取实例的属性列表
        /// </summary>
        /// <param name="obj">实例信息</param>
        /// <param name="ignoreProperties">忽略的属性名字</param>
        /// <returns>实例的属性列表</returns>
        public static List<PropertyInfo> GetPropertyInfos(object obj, string[] ignoreProperties)
        {
            List<PropertyInfo> proList = GetPropertyInfos(obj)
                                                    .Where(m =>
                                                    {
                                                        if (ignoreProperties == null) return true;
                                                        if (ignoreProperties.Contains(m.Name)) return false;
                                                        return true;
                                                    }).ToList();
            return proList;
        }

        /// <summary>
        /// 获取实例的属性列表
        /// </summary>
        /// <param name="obj">实例信息</param>
        /// <returns>实例的属性列表</returns>
        public static List<PropertyInfo> GetPropertyInfos(object obj)
        {
            if (obj == null)
            {
                return new List<PropertyInfo>();
            }
            return GetTypeProperties(obj.GetType());
        }

        /// <summary>
        /// 根据类型获取类型的属性信息
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="ignoreProperties">要忽略的属性</param>
        /// <returns>类型的</returns>
        public static List<PropertyInfo> GetTypeProperties(Type type, string[] ignoreProperties)
        {
            return GetTypeProperties(type).Where(m =>
            {
                if (ignoreProperties == null) return true;
                if (ignoreProperties.Contains(m.Name)) return false;
                return true;
            }).ToList();
        }

        /// <summary>
        /// 根据类型获取类型的属性信息
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>类型的</returns>
        public static List<PropertyInfo> GetTypeProperties(Type type)
        {
            if (type == null) return new List<PropertyInfo>();
            var typeHandle = type.TypeHandle;
            return _propertyCache.GetValue(typeHandle, () =>
            {
                return type.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            });
        }
    }
}