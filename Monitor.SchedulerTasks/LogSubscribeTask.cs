using JQ;
using JQ.MQ;
using JQ.MQ.Logger;
using JQ.Utils;
using Monitor.Infrastructure.MQ;
using Monitor.IUserApplication;
using System.Collections.Generic;
using System.ComponentModel;

namespace Monitor.SchedulerTasks
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：LogSubscribeTask.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/29 13:42:33
    /// </summary>
    public sealed class LogSubscribeTask : JQDisposable
    {
        private IMQClient mqClient;
        private readonly IRuntimeLogApplication _runtimeLogApplication;
        private readonly IMQFactory _mqFactory;

        public LogSubscribeTask(IRuntimeLogApplication runtimeLogApplication, IMQFactory mqFactory)
        {
            _runtimeLogApplication = runtimeLogApplication;
            _mqFactory = mqFactory;
        }

        /// <summary>
        /// 启动监听日志消息
        /// </summary>
        [DisplayName("监听日志消息任务")]
        public void Start()
        {
            mqClient = _mqFactory.Create(MQLoggerUtil.GetMQLoggerConfig());
            mqClient.Subscribe<List<JQLoggerMessage>>((messageList) =>
            {
                _runtimeLogApplication.AddManyLog(messageList);
            }, exchangeName: "JQ.Message.Exchange", queueName: "JQ.Message.Queue", routingKey: "JQ.LoggerMessage.*", exchangeType: MQExchangeType.TOPICS, errorActionHandle: (message, ex) =>
            {
                LogUtil.Error(ex, memberName: "LoggerSubscribeTask-Install-Subscribe");
            }, memberName: "LoggerSubscribeTask-DealLog");
        }

        protected override void DisposeCode()
        {
            LogUtil.Info("执行释放LoggerSubscribeTask-DisposeCode");
            LogUtil.Info("【停止】监听日志消息任务");
            mqClient?.Dispose();
        }
    }
}