using JQ.MQ.Logger;
using JQ.Result;
using Monitor.Domain.IDomainServer;
using Monitor.Domain.IRepository;
using Monitor.IUserApplication;
using System.Collections.Generic;

namespace Monitor.UserApplication
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RuntimeLogApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/27 15:33:44
    /// </summary>
    public sealed class RuntimeLogApplication : IRuntimeLogApplication
    {
        private readonly IRuntimeLogDomainServer _runtimeLogDomainServer;
        private readonly IRuntimeLogRepository _runtimeLogRepository;

        public RuntimeLogApplication(IRuntimeLogDomainServer runtimeLogDomainServer, IRuntimeLogRepository runtimeLogRepository)
        {
            _runtimeLogDomainServer = runtimeLogDomainServer;
            _runtimeLogRepository = runtimeLogRepository;
        }

        /// <summary>
        /// 添加多条消息
        /// </summary>
        /// <param name="loggerMessageList">日志信息集合</param>
        /// <returns>多条消息</returns>
        public OperateResult AddManyLog(List<JQLoggerMessage> loggerMessageList)
        {
            var logList = _runtimeLogDomainServer.CreateRunTimeLogList(loggerMessageList);
            _runtimeLogRepository.InsertMany(logList);
            return OperateUtil.Success("添加成功");
        }
    }
}