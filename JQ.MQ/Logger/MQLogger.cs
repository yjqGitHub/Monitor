using JQ.Configurations;
using JQ.Logger;
using JQ.Utils;
using System;
using System.Collections.Generic;

namespace JQ.MQ.Logger
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RabbitMQLogger.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：队列日志记录器
    /// 创建标识：yjq 2017/6/12 20:59:29
    /// </summary>
    public sealed class MQLogger : ILogger
    {
        internal static Func<MQLoggerConfig> GetMQLoggerConfigAction;
        internal static BufferQueue<JQLoggerMessage> _MessageQueue = new BufferQueue<JQLoggerMessage>(20000, MessageHandle, HaveNoCountHandle);

        private readonly string _loggerName;

        public MQLogger(string loggerName)
        {
            _loggerName = loggerName;
        }

        /// <summary>
        /// 获取MQLoggerConfig的服务器配置
        /// </summary>
        /// <returns></returns>
        private static MQLoggerConfig GetConfig()
        {
            if (GetMQLoggerConfigAction != null)
            {
                var config = GetMQLoggerConfigAction();
                if (config != null)
                {
                    return config;
                }
            }
            throw new NotSupportedException("获取MQLoggerConfig的方法不能为空");
        }

        #region SendMessage

        public void Debug(string message)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Debug, message);
            SendLog(loggerMessage);
        }

        public void DebugFormat(string format, params object[] args)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Debug, string.Format(format, args));
            SendLog(loggerMessage);
        }

        public void Error(Exception exception)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Error, exception);
            SendLog(loggerMessage);
        }

        public void Error(string message)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Error, message);
            SendLog(loggerMessage);
        }

        public void Error(string message, Exception exception)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Error, message, exception);
            SendLog(loggerMessage);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Error, string.Format(format, args));
            SendLog(loggerMessage);
        }

        public void Fatal(Exception exception)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Fatal, exception);
            SendLog(loggerMessage);
        }

        public void Fatal(string message)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Fatal, message);
            SendLog(loggerMessage);
        }

        public void Fatal(string message, Exception exception)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Fatal, message, exception);
            SendLog(loggerMessage);
        }

        public void FatalFormat(string format, params object[] args)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Fatal, string.Format(format, args));
            SendLog(loggerMessage);
        }

        public void Info(string message)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Info, message);
            SendLog(loggerMessage);
        }

        public void InfoFormat(string format, params object[] args)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Info, string.Format(format, args));
            SendLog(loggerMessage);
        }

        public void Warn(Exception exception)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Warn, exception);
            SendLog(loggerMessage);
        }

        public void Warn(string message)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Warn, message);
            SendLog(loggerMessage);
        }

        public void Warn(string message, Exception exception)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Warn, message, exception);
            SendLog(loggerMessage);
        }

        public void WarnFormat(string format, params object[] args)
        {
            var loggerMessage = GetLoggerMessage(MessageType.Warn, string.Format(format, args));
            SendLog(loggerMessage);
        }

        #endregion SendMessage

        /// <summary>
        /// 消息内容
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <param name="message">消息内容</param>
        /// <returns>消息内容</returns>
        private JQLoggerMessage GetLoggerMessage(MessageType messageType, string message)
        {
            var loggerMessage = new JQLoggerMessage();
            loggerMessage.SetMessage(_loggerName, messageType, message);
            return loggerMessage;
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <param name="ex">异常信息</param>
        /// <returns>消息内容</returns>
        private JQLoggerMessage GetLoggerMessage(MessageType messageType, Exception ex)
        {
            var loggerMessage = new JQLoggerMessage();
            loggerMessage.SetMessage(_loggerName, messageType, ex);
            return loggerMessage;
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <param name="message">消息内容</param>
        /// <param name="exception">异常信息</param>
        /// <returns>消息内容</returns>
        private JQLoggerMessage GetLoggerMessage(MessageType messageType, string message, Exception ex)
        {
            var loggerMessage = new JQLoggerMessage();
            loggerMessage.SetMessage(_loggerName, messageType, message, ex);
            return loggerMessage;
        }

        private const string _exchangeName = "JQ.Message.Exchange";

        /// <summary>
        /// 发送日志
        /// </summary>
        /// <param name="message">消息内容</param>
        private void SendLog(JQLoggerMessage message)
        {
            _MessageQueue.EnqueueMessage(message);
            //var conifg = GetConfig();
            //var mqClient = JQConfiguration.Resolve<IMQFactory>().Create(conifg);
            //string queueName = "JQ.Message.Queue";
            //string routeKey = string.Concat("JQ.LoggerMessage.", message.MessageType.ToString());
            //mqClient.Publish(message, _exchangeName, queueName, routeKey, exchangeType: MQExchangeType.TOPICS, durable: true);
        }

        /// <summary>
        /// 消息列表
        /// </summary>
        private static List<JQLoggerMessage> _MessageList = new List<JQLoggerMessage>();

        /// <summary>
        /// 当前正在处理的信息数量
        /// </summary>
        private static int _CurrentDealCount = 0;

        private static void MessageHandle(JQLoggerMessage message)
        {
            if (_CurrentDealCount >= 50)
            {
                SendMessage();
            }
            else
            {
                _MessageList.Add(message);
                _CurrentDealCount++;
            }
        }

        private static void HaveNoCountHandle()
        {
            if (_CurrentDealCount > 0)
            {
                SendMessage();
            }
        }

        private static void SendMessage()
        {
            if (_CurrentDealCount > 0)
            {
                ExceptionUtil.LogException(() =>
                {
                    var conifg = GetConfig();
                    var mqClient = JQConfiguration.Resolve<IMQFactory>().Create(conifg);
                    string queueName = "JQ.Message.Queue";
                    string routeKey = string.Concat("JQ.LoggerMessage.List");
                    mqClient.Publish(_MessageList, _exchangeName, queueName, routeKey, exchangeType: MQExchangeType.TOPICS, durable: true);
                }, memberName: "MQLogger-MessageHandle-SendMessag");
                _MessageList.Clear();
                _CurrentDealCount = 0;
            }
        }
    }
}