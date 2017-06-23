using JQ.Serialization;
using JQ.Serialization.NewtonsoftJson;

namespace JQ.Redis.Serialization
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RedisJsonBinarySerializer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/23 11:40:16
    /// </summary>
    public class RedisJsonBinarySerializer : NewtonsoftJsonBinarySerializer, IRedisBinarySerializer
    {
        public RedisJsonBinarySerializer(IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
        }
    }
}