using JQ.Configurations;
using JQ.MQ;
using JQ.MQ.Logger;
using JQ.Utils;
using Monitor.Infrastructure.MQ;
using Monitor.IUserApplication;
using System.Collections.Generic;

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
            var runtimeLogApplication = JQConfiguration.Resolve<IRuntimeLogApplication>();
            var mqFactory = JQConfiguration.Resolve<IMQFactory>();
            mqClient = mqFactory.Create(MQLoggerUtil.GetMQLoggerConfig());
            mqClient.Subscribe<List<JQLoggerMessage>>((messageList) =>
            {
                runtimeLogApplication.AddManyLog(messageList);
            }, exchangeName: "JQ.Message.Exchange", queueName: "JQ.Message.Queue", routingKey: "JQ.LoggerMessage.*", exchangeType: MQExchangeType.TOPICS, errorActionHandle: (message, ex) =>
            {
                LogUtil.Error(ex, memberName: "LoggerSubscribeTask-Install-Subscribe");
            }, memberName: "LoggerSubscribeTask-DealLog");
        }

        public void Unstall()
        {
            mqClient.Dispose();
        }
    }
}