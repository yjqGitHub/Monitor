using JQ.Configurations;
using JQ.Extensions;
using ProtoBuf;
using System;

namespace JQ.MQ.Logger
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：LoggerMessage.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：日志信息
    /// 创建标识：yjq 2017/6/12 21:01:08
    /// </summary>
    [ProtoContract]
    public class JQLoggerMessage : ILoggerMessage
    {
        public JQLoggerMessage()
        {
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        [ProtoMember(1)]
        public string AppDomain { get; set; }

        /// <summary>
        /// 记录器名字
        /// </summary>
        [ProtoMember(2)]
        public string LoggerName { get; set; }

        /// <summary>
        /// 日志消息类型
        /// </summary>
        [ProtoMember(3)]
        public MessageType MessageType { get; set; }

        /// <summary>
        /// 日志信息内容
        /// </summary>
        [ProtoMember(4)]
        public string Message { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ProtoMember(5)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 设置信息内容
        /// </summary>
        /// <param name="loggerName">记录器名字</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="message">消息内容</param>
        public virtual void SetMessage(string loggerName, MessageType messageType, string message)
        {
            AppDomain = JQConfiguration.Instance.AppDomainName;
            LoggerName = loggerName;
            CreateTime = DateTime.Now;
            MessageType = messageType;
            Message = message;
        }

        /// <summary>
        /// 设置信息内容
        /// </summary>
        /// <param name="loggerName">记录器名字</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="ex">异常信息</param>
        public virtual void SetMessage(string loggerName, MessageType messageType, Exception ex)
        {
            SetMessage(loggerName, messageType, ex.ToErrMsg());
        }

        /// <summary>
        /// 设置信息内容
        /// </summary>
        /// <param name="loggerName">记录器名字</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="message">消息内容</param>
        /// <param name="exception">异常信息</param>
        public virtual void SetMessage(string loggerName, MessageType messageType, string message, Exception exception)
        {
            SetMessage(loggerName, messageType, string.Concat(message, Environment.NewLine, exception.ToErrMsg()));
        }
    }
}