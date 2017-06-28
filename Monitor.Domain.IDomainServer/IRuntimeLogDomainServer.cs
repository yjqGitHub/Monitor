using JQ.MQ.Logger;
using Monitor.Domain.Model;
using System.Collections.Generic;

namespace Monitor.Domain.IDomainServer
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IRuntimeLogDomainServer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IRuntimeLogDomainServer接口
    /// 创建标识：yjq 2017/6/27 15:15:45
    /// </summary>
    public interface IRuntimeLogDomainServer
    {
        /// <summary>
        /// 创建一个运行时日志信息
        /// </summary>
        /// <param name="loggerMessage">记录信息</param>
        /// <returns>运行时日志信息</returns>
        RuntimeLogInfo CreateRunTimeLogInfo(JQLoggerMessage loggerMessage);

        /// <summary>
        /// 创建运行日志集合
        /// </summary>
        /// <param name="loggerMessageList">记录信息集合</param>
        /// <returns>运行日志集合</returns>
        List<RuntimeLogInfo> CreateRunTimeLogList(List<JQLoggerMessage> loggerMessageList);
    }
}