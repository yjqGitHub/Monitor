using System;

namespace JQ.MQ.Logger
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ILoggerMessage.cs
    /// 类属性：接口
    /// 类功能描述：日志信息
    /// 创建标识：yjq 2017/6/14 20:10:33
    /// </summary>
    public interface ILoggerMessage
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        string AppDomain { get; set; }

        /// <summary>
        /// 记录器名字
        /// </summary>
        string LoggerName { get; set; }

        /// <summary>
        /// 日志消息类型
        /// </summary>
        MessageType MessageType { get; set; }

        /// <summary>
        /// 日志信息内容
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        /// 设置信息内容
        /// </summary>
        /// <param name="loggerName">记录器名字</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="message">消息内容</param>
        void SetMessage(string loggerName, MessageType messageType, string message);

        /// <summary>
        /// 设置信息内容
        /// </summary>
        /// <param name="loggerName">记录器名字</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="ex">异常信息</param>
        void SetMessage(string loggerName, MessageType messageType, Exception ex);

        /// <summary>
        /// 设置信息内容
        /// </summary>
        /// <param name="loggerName">记录器名字</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="message">消息内容</param>
        /// <param name="exception">异常信息</param>
        void SetMessage(string loggerName, MessageType messageType, string message, Exception exception);
    }
}