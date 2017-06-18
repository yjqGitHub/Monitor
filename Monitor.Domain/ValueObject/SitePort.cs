using System.ComponentModel;

namespace Monitor.Domain.ValueObject
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：SitePort.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：站点端口枚举
    /// 创建标识：yjq 2017/6/18 16:45:26
    /// </summary>
    public enum SitePort
    {
        /// <summary>
        /// 手机端
        /// </summary>
        [Description("手机端")]
        App = 5,

        /// <summary>
        /// 电脑端
        /// </summary>
        [Description("电脑端")]
        WebPC = 10,

        /// <summary>
        /// 微信
        /// </summary>
        [Description("微信")]
        Wechat = 15,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 100
    }
}