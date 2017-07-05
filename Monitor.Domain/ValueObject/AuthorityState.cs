using System.ComponentModel;

namespace Monitor.Domain.ValueObject
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AuthorityState.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：授权状态
    /// 创建标识：yjq 2017/7/5 15:25:23
    /// </summary>
    public enum AuthorityState
    {
        /// <summary>
        /// 已授权
        /// </summary>
        [Description("已授权")]
        Authoritied = 1,

        /// <summary>
        /// 已过期
        /// </summary>
        [Description("已过期")]
        Invalid = 10
    }
}