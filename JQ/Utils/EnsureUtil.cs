using JQ.Extensions;
using System;

namespace JQ.Utils
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：EnsureUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：EnsureUtil
    /// 创建标识：yjq 2017/6/16 22:36:00
    /// </summary>
    public static class EnsureUtil
    {
        /// <summary>
        /// 判断值不为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">要判断的值</param>
        /// <param name="argument">字段</param>
        public static void NotNull<T>(T value, string argument)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argument);
            }
        }

        #region 字符串判断

        /// <summary>
        /// 判断字符串不是 null、空、不是由空白字符组成。
        /// </summary>
        /// <param name="input">要判断的字符</param>
        /// <param name="msg">字段</param>
        public static void NotNullAndNotEmptyWhiteSpace(object input, string argument)
        {
            if (input.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(argument);
            }
        }

        #endregion 字符串判断
    }
}