using JQ.Configurations;
using JQ.Logger;
using System;

namespace JQ.MQ.Logger
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MQLoggerMessageConfigExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：配置扩展类
    /// 创建标识：yjq 2017/6/14 21:03:57
    /// </summary>
    public static class MQLoggerMessageConfigurationExtension
    {
        private const string REGISTER_NAME_MQLOGGERFACTORY = "MQLoggerFactory";

        /// <summary>
        ///
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="action">获取MQLoggerConfig的方法</param>
        /// <returns></returns>
        public static JQConfiguration UseMQLogger(this JQConfiguration configuration, Func<MQLoggerConfig> action)
        {
            if (action == null)
            {
                throw new NotSupportedException("请设置获取MQLoggerConfig的方法");
            }
            configuration.SetDefault<ILoggerFactory, MQLoggerFactory>(serviceName: REGISTER_NAME_MQLOGGERFACTORY);
            configuration.SetDefault<ILoggerMessage, JQLoggerMessage>();
            configuration.AddRegisterName(typeof(MQLoggerFactory).TypeHandle, REGISTER_NAME_MQLOGGERFACTORY);
            MQLogger.GetMQLoggerConfigAction = action;
            configuration.AddUnstallAction(() => { MQLogger.GetMQLoggerConfigAction = null; });
            return configuration;
        }
    }
}