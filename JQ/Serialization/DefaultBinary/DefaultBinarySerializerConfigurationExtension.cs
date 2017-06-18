using JQ.Configurations;

namespace JQ.Serialization.DefaultBinary
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：DefaultBinarySerializerConfigExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：DefaultBinarySerializerConfigExtension
    /// 创建标识：yjq 2017/6/11 18:15:02
    /// </summary>
    public static class DefaultBinarySerializerConfigurationExtension
    {
        private const string REGISTER_NAME_DEFAULTBINARY = "DefaultBinary";

        public static JQConfiguration UseDefaultBinarySerializer(this JQConfiguration configuration)
        {
            configuration.SetDefault<IBinarySerializer, DefaultBinarySerializer>(serviceName: REGISTER_NAME_DEFAULTBINARY);
            configuration.AddRegisterName(typeof(DefaultBinarySerializer).TypeHandle, REGISTER_NAME_DEFAULTBINARY);
            return configuration;
        }
    }
}