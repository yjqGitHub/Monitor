using JQ.Configurations;
using JQ.MQ;
using JQ.MQ.Logger;
using Monitor.Infrastructure.MQ;
using System;

namespace Monitor.TaskScheduling
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：LoggerSubscribeTask.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：日志记录器监听任务
    /// 创建标识：yjq 2017/6/26 13:29:17
    /// </summary>
    public sealed class LoggerSubscribeTask
    {
        private IMQClient mqClient;

        public LoggerSubscribeTask()
        {
        }

        public void Install()
        {
            var mqFactory = JQConfiguration.Resolve<IMQFactory>();
            mqClient = mqFactory.Create(MQLoggerUtil.GetMQLoggerConfig());
            mqClient.Subscribe<ILoggerMessage>((message) =>
            {
                Console.WriteLine(message.ToString());
            }, exchangeName: "JQ.Message.Exchange", queueName: "JQ.Message.Queue", routingKey: "JQ.LoggerMessage.*", exchangeType: MQExchangeType.TOPICS, errorActionHandle: (message, ex) => { }, memberName: "LoggerSubscribeTask-DealLog");
        }

        public void Unstall()
        {
            mqClient.Dispose();
        }
    }
}