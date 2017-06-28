using JQ.MQ.Logger;
using JQ.Result;
using System.Collections.Generic;

namespace Monitor.IUserApplication
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IRuntimeLogApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IRuntimeLogApplication接口
    /// 创建标识：yjq 2017/6/27 15:33:24
    /// </summary>
    public interface IRuntimeLogApplication
    {
        /// <summary>
        /// 添加多条消息
        /// </summary>
        /// <param name="loggerMessageList">日志信息集合</param>
        /// <returns>多条消息</returns>
        OperateResult AddManyLog(List<JQLoggerMessage> loggerMessageList);
    }
}