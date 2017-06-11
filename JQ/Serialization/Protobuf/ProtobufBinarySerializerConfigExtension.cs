using JQ.Configurations;

namespace JQ.Serialization.Protobuf
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ProtobufBinarySerializerConfigExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ProtobufBinarySerializerConfigExtension
    /// 创建标识：yjq 2017/6/11 18:43:53
    /// </summary>
    public static class ProtobufBinarySerializerConfigExtension
    {
        private const string REGISTER_NAME_PROTOBUFBINARY = "ProtobufBinary";

        public static JQConfiguration UseProtobufBinarySerializer(this JQConfiguration configuration)
        {
            configuration.SetDefault<IBinarySerializer, ProtobufBinarySerializer>(serviceName: REGISTER_NAME_PROTOBUFBINARY);
            configuration.AddRegisterName(typeof(ProtobufBinarySerializer).TypeHandle, REGISTER_NAME_PROTOBUFBINARY);
            return configuration;
        }
    }
}