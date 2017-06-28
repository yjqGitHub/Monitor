using JQ.MQ.Logger;
using JQ.ParamterValidate;
using Monitor.Domain.IDomainServer;
using Monitor.Domain.IRepository;
using Monitor.Domain.Model;
using Monitor.Domain.ValueObject;
using System;
using System.Collections.Generic;

namespace Monitor.Domain.DomainServer
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RuntimeLogDomainServer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/27 15:16:11
    /// </summary>
    public sealed class RuntimeLogDomainServer : IRuntimeLogDomainServer
    {
        private readonly IRuntimeLogRepository _runtimeLogRepository;

        public RuntimeLogDomainServer(IRuntimeLogRepository runtimeLogRepository)
        {
            _runtimeLogRepository = runtimeLogRepository;
        }

        /// <summary>
        /// 创建一个运行时日志信息
        /// </summary>
        /// <param name="loggerMessage">记录信息</param>
        /// <returns>运行时日志信息</returns>
        public RuntimeLogInfo CreateRunTimeLogInfo(JQLoggerMessage loggerMessage)
        {
            loggerMessage.NotNull("日志信息不能为空");
            var runtimeLogInfo = new RuntimeLogInfo
            {
                AppDomain = loggerMessage.AppDomain,
                CreateTime = DateTime.Now,
                LoggerName = loggerMessage.LoggerName,
                LogTime = loggerMessage.CreateTime,
                Message = loggerMessage.Message
            };
            runtimeLogInfo.SetLogType(loggerMessage.MessageType);
            if (runtimeLogInfo.LogType == RuntimeLogType.Error || runtimeLogInfo.LogType == RuntimeLogType.Fatal || runtimeLogInfo.LogType == RuntimeLogType.Warn)
            {
                runtimeLogInfo.IsDealed = false;
                runtimeLogInfo.IsNeedWaring = true;
            }
            else
            {
                runtimeLogInfo.IsDealed = true;
                runtimeLogInfo.IsNeedWaring = false;
            }
            return runtimeLogInfo;
        }

        /// <summary>
        /// 创建运行日志集合
        /// </summary>
        /// <param name="loggerMessageList">记录信息集合</param>
        /// <returns>运行日志集合</returns>
        public List<RuntimeLogInfo> CreateRunTimeLogList(List<JQLoggerMessage> loggerMessageList)
        {
            if (loggerMessageList == null || loggerMessageList.Count <= 0)
            {
                throw new JQ.JQException("日志信息不能为空");
            }
            var logList = new List<RuntimeLogInfo>();
            foreach (var item in loggerMessageList)
            {
                logList.Add(CreateRunTimeLogInfo(item));
            }
            return logList;
        }
    }
}