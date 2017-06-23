using JQ.Serialization;
using JQ.Serialization.NewtonsoftJson;

namespace JQ.MQ.Serialization
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MQJsonBinarySerializer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MQ json序列化
    /// 创建标识：yjq 2017/6/23 11:46:10
    /// </summary>
    public sealed class MQJsonBinarySerializer : NewtonsoftJsonBinarySerializer, IMQBinarySerializer
    {
        public MQJsonBinarySerializer(IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
        }
    }
}