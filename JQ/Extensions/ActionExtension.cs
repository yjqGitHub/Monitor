using System;

namespace JQ.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ActionExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：方法扩展类
    /// 创建标识：yjq 2017/6/10 23:19:29
    /// </summary>
    public static partial class ActionExtension
    {
        /// <summary>
        /// 当对象不为空且不是由空白字符组成是才执行方法
        /// </summary>
        /// <param name="obj">要判断的对象</param>
        /// <param name="action">要执行的方法</param>
        public static void IsNotNullAndNotWhiteSpaceThenExcute(this object obj, Action action)
        {
            if (obj.IsNotNullAndNotWhiteSpace())
            {
                action();
            }
        }

        /// <summary>
        /// 当对象为空或者空白字符串组成时执行
        /// </summary>
        /// <param name="obj">要判断的对象</param>
        /// <param name="action">要执行的方法</param>
        public static void IsNullOrWhiteSpaceThenExcute(this object obj, Action action)
        {
            if (obj.IsNullOrWhiteSpace())
            {
                action();
            }
        }
    }
}