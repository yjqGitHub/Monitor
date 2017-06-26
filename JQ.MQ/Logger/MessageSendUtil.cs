using JQ.Configurations;
using JQ.Utils;
using System;
using System.Collections.Generic;

namespace JQ.MQ.Logger
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：MessageSendUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MessageSendUtil
    /// 创建标识：yjq 2017/6/27 0:00:29
    /// </summary>
    public sealed class MessageSendUtil
    {
        internal static Func<MQLoggerConfig> GetMQLoggerConfigAction;
        internal static BufferQueue<JQLoggerMessage> _MessageQueue = new BufferQueue<JQLoggerMessage>(20000, MessageHandle, HaveNoCountHandle);
        private const string _EXCHANGENAME = "JQ.Message.Exchange";

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

        /// <summary>
        /// 消息列表
        /// </summary>
        private static Dictionary<MessageType, List<JQLoggerMessage>> _MessageDic = new Dictionary<MessageType, List<JQLoggerMessage>>();

        private static void MessageHandle(JQLoggerMessage message)
        {
            if (_MessageDic.ContainsKey(message.MessageType))
            {
                if (_MessageDic[message.MessageType].Count > 50)
                {
                    SendMessage(message.MessageType, _MessageDic[message.MessageType]);
                    _MessageDic[message.MessageType].Clear();
                }
                _MessageDic[message.MessageType].Add(message);
            }
            else
            {
                _MessageDic.Add(message.MessageType, new List<JQLoggerMessage>() { message });
            }
        }

        private static void HaveNoCountHandle()
        {
            foreach (var item in _MessageDic)
            {
                SendMessage(item.Key, item.Value);
                item.Value?.Clear();
            }
        }

        private static void SendMessage(MessageType messageType, List<JQLoggerMessage> messageList)
        {
            if (messageList != null && messageList.Count > 0)
            {
                ExceptionUtil.LogException(() =>
                {
                    var conifg = GetConfig();
                    var mqClient = JQConfiguration.Resolve<IMQFactory>().Create(conifg);
                    string queueName = "JQ.Message.Queue";
                    string routeKey = string.Concat("JQ.LoggerMessage.", messageType.ToString());
                    mqClient.Publish(messageList, _EXCHANGENAME, queueName, routeKey, exchangeType: MQExchangeType.TOPICS, durable: true);
                }, memberName: "MQLogger-MessageHandle-SendMessag");
            }
        }
    }
}