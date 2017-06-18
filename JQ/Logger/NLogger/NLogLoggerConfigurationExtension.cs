using JQ.Configurations;

namespace JQ.Logger.NLogger
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：NLogLoggerConfigExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：NLogLoggerConfigExtension
    /// 创建标识：yjq 2017/6/11 21:48:39
    /// </summary>
    public static class NLogLoggerConfigurationExtension
    {
        private const string REGISTER_NAME_NLOGFACTORY = "NLogFactory";

        public static JQConfiguration UseNLog(this JQConfiguration configuration)
        {
            configuration.SetDefault<ILoggerFactory, NLoggerFactory>(serviceName: REGISTER_NAME_NLOGFACTORY);
            configuration.AddRegisterName(typeof(NLoggerFactory).TypeHandle, REGISTER_NAME_NLOGFACTORY);
            return configuration;
        }
    }
}