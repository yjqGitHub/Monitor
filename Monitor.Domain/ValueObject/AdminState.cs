using System.ComponentModel;

namespace Monitor.Domain.ValueObject
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AdminState.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员状态
    /// 创建标识：yjq 2017/6/18 20:56:34
    /// </summary>
    public enum AdminState
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