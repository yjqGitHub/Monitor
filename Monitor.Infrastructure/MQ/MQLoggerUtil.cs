using JQ.MQ.Logger;
using JQ.Utils;

namespace Monitor.Infrastructure.MQ
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MQLoggerUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MQ日志记录器工具类
    /// 创建标识：yjq 2017/6/23 13:14:46
    /// </summary>
    public sealed class MQLoggerUtil
    {
        /// <summary>
        /// MQ Logger的连接配置Key
        /// </summary>
        private const string _MQLOGGER_CONNECTION_KEY = "MQLogger.Connection";

        /// <summary>
        /// MQ Logger的UserName配置Key
        /// </summary>
        private const string _MQLOGGER_USERNAME_KEY = "MQLogger.UserName";

        /// <summary>
        /// MQ Logger的OWD配置Key
        /// </summary>
        private const string _MQLOGGER_PWD_KEY = "MQLogger.Pwd";

        /// <summary>
        /// MQ Logger的VirtualHost配置Key
        /// </summary>
        private const string _MQLOGGER_VIRTUALHOST_KEY = "MQLogger.VirtualHost";

        /// <summary>
        /// 获取MQLogger的配置信息
        /// </summary>
        /// <returns></returns>
        public static MQLoggerConfig GetMQLoggerConfig()
        {
            string connection = ConfigUtil.GetValue(_MQLOGGER_CONNECTION_KEY, memberName: "MQLoggerUtil-GetMQLoggerConfig");
            string userName = ConfigUtil.GetValue(_MQLOGGER_USERNAME_KEY, memberName: "MQLoggerUtil-GetMQLoggerConfig");
            string pwd = ConfigUtil.GetValue(_MQLOGGER_PWD_KEY, memberName: "MQLoggerUtil-GetMQLoggerConfig");
            string virtualHost = ConfigUtil.GetValue(_MQLOGGER_VIRTUALHOST_KEY, memberName: "MQLoggerUtil-GetMQLoggerConfig");
            return new MQLoggerConfig(connection, userName, pwd)
            {
                VirtualHost = virtualHost
            };
        }
    }
}