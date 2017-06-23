using JQ.Configurations;

namespace JQ.MQ.Serialization
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MQBinarySerializerConfigurationExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MQBinarySerializer配置扩展类
    /// 创建标识：yjq 2017/6/23 11:49:55
    /// </summary>
    public static class MQBinarySerializerConfigurationExtension
    {
        private const string REGISTER_NAME_MQJSONBINARY = "MQJsonBinary";

        public static JQConfiguration UseMQJsonBinarySerializer(this JQConfiguration configuration)
        {
            configuration.SetDefault<IMQBinarySerializer, MQJsonBinarySerializer>(serviceName: REGISTER_NAME_MQJSONBINARY);
            configuration.AddRegisterName(typeof(MQJsonBinarySerializer).TypeHandle, REGISTER_NAME_MQJSONBINARY);
            return configuration;
        }

        private const string REGISTER_NAME_MQPROTOBUFBINARY = "MQProtobufBinary";

        public static JQConfiguration UseMQProtobufBinarySerializer(this JQConfiguration configuration)
        {
            configuration.SetDefault<IMQBinarySerializer, MQProtobufBinarySerializer>(serviceName: REGISTER_NAME_MQPROTOBUFBINARY);
            configuration.AddRegisterName(typeof(MQProtobufBinarySerializer).TypeHandle, REGISTER_NAME_MQPROTOBUFBINARY);
            return configuration;
        }
    }
}