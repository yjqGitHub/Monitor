using System.ComponentModel;

namespace Monitor.Domain.ValueObject
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：SiteState.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：站点状态枚举
    /// 创建标识：yjq 2017/7/1 14:55:00
    /// </summary>
    public enum SiteState
    {
        /// <summary>
        /// 未激活
        /// </summary>
        [Description("未激活")]
        NotActive = 1,

        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 10,

        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disabled = 20
    }
}