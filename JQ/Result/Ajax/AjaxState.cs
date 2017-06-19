using System.ComponentModel;

namespace JQ.Result
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AjaxState.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AjaxState
    /// 创建标识：yjq 2017/6/11 0:29:19
    /// </summary>
    public enum AjaxState
    {
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Failed = 90000,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 10000,

        /// <summary>
        /// 未登录
        /// </summary>
        [Description("未登录")]
        NoLogin = 99999
    }
}