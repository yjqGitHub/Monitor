﻿using System;

namespace JQ.ParamterValidate
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ParameterCheck.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ParameterCheck
    /// 创建标识：yjq 2017/6/10 11:33:02
    /// </summary>
    public static class ParameterCheck
    {
        /// <summary>
        /// 判断值不为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">要判断的值</param>
        /// <param name="argument">错误后要提示的信息</param>
        public static void NotNull<T>(this T value, string argument)
        {
            if (value == null)
            {
                throw new JQException(argument);
            }
        }

        #region 比较是否大于、小于、等于

        /// <summary>
        /// 比较是否大于等于
        /// </summary>
        /// <typeparam name="T">比较的类型</typeparam>
        /// <param name="compareValue">要判断的值</param>
        /// <param name="targetValue">被比较的值</param>
        /// <param name="msg">错误内容</param>
        public static void GreaterThanOrEqual<T>(this T @compareValue, T targetValue, string msg) where T : IComparable<T>
        {
            if (@compareValue.CompareTo(targetValue) < 0)
            {
                throw new JQException(msg);
            }
        }

        /// <summary>
        /// 比较是否大于
        /// </summary>
        /// <typeparam name="T">比较的类型</typeparam>
        /// <param name="compareValue">要判断的值</param>
        /// <param name="targetValue">被比较的值</param>
        /// <param name="msg">错误内容</param>
        public static void GreaterThan<T>(this T @compareValue, T targetValue, string msg) where T : IComparable<T>
        {
            if (@compareValue.CompareTo(targetValue) <= 0)
            {
                throw new JQException(msg);
            }
        }

        #endregion 比较是否大于、小于、等于

        #region 字符串判断

        /// <summary>
        /// 判断字符串不是 null、空、不是由空白字符组成。
        /// </summary>
        /// <param name="input">要判断的字符</param>
        /// <param name="msg">错误信息</param>
        public static void NotNullAndNotEmptyWhiteSpace(this object input, string msg)
        {
            if (input == null)
            {
                throw new JQException(msg);
            }
            if (string.IsNullOrWhiteSpace(input.ToString()))
            {
                throw new JQException(msg);
            }
        }

        #endregion 字符串判断
    }
}