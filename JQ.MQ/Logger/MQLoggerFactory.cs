using JQ.Logger;
using System;

namespace JQ.MQ.Logger
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MQLoggerFactory.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/14 20:50:03
    /// </summary>
    public class MQLoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// 根据loggerName创建ILogger
        /// </summary>
        /// <param name="loggerName">logger名字</param>
        /// <returns>ILogger</returns>
        public ILogger Create(Type loggerType)
        {
            string loggerName = string.Empty;
            if (loggerType != null)
            {
                loggerName = loggerType.Name;
            }
            return Create(loggerName);
        }

        /// <summary>
        /// 根据类型创建ILogger
        /// </summary>
        /// <param name="loggerType">logger类型</param>
        /// <returns>ILogger</returns>
        public ILogger Create(string loggerName)
        {
            return new MQLogger(loggerName);
        }
    }
}