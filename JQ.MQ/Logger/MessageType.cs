using System.ComponentModel;

namespace JQ.MQ.Logger
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MessageType.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：消息类型
    /// 创建标识：yjq 2017/6/12 21:02:43
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        ///调试日志
        /// </summary>
        [Description("调试日志")]
        Debug = 1,

        /// <summary>
        ///普通日志
        /// </summary>
        [Description("普通日志")]
        Info = 2,

        /// <summary>
        ///警告日志
        /// </summary>
        [Description("警告日志")]
        Warn = 3,

        /// <summary>
        ///错误日志
        /// </summary>
        [Description("错误日志")]
        Error = 4,

        /// <summary>
        ///严重错误日志
        /// </summary>
        [Description("严重错误日志")]
        Fatal = 5
    }
}