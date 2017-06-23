using JQ.Serialization;
using JQ.Serialization.Protobuf;

namespace JQ.MQ.Serialization
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MQProtobufBinarySerializer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MQProtobuf序列化
    /// 创建标识：yjq 2017/6/23 11:43:47
    /// </summary>
    public class MQProtobufBinarySerializer : ProtobufBinarySerializer, IMQBinarySerializer
    {
        public MQProtobufBinarySerializer(IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
        }
    }
}