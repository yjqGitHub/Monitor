using JQ.Serialization.NewtonsoftJson;
using JQ.Utils;
using ProtoBuf;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace JQ.Serialization.Protobuf
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ProtobufBinarySerializer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ProtobufBinarySerializer
    /// 创建标识：yjq 2017/6/11 18:36:53
    /// </summary>
    public class ProtobufBinarySerializer : NewtonsoftJsonBinarySerializer, IBinarySerializer
    {
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, bool> _isHaveProtoContractCache = new ConcurrentDictionary<RuntimeTypeHandle, bool>();

        public ProtobufBinarySerializer(IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="serializedObject">字节数组</param>
        /// <returns>对象</returns>
        public override T Deserialize<T>(byte[] serializedObject)
        {
            var type = typeof(T);
            if (!IsHaveProtoContract(type))
            {
                return base.Deserialize<T>(serializedObject);
            }
            using (var ms = new MemoryStream(serializedObject))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }

        /// <summary>
        /// 异步反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="serializedObject">字节数组</param>
        /// <returns>对象</returns>
        public override Task<T> DeserializeAsync<T>(byte[] serializedObject)
        {
            return Task.Factory.StartNew(() => Deserialize<T>(serializedObject));
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="item">对象值</param>
        /// <returns>字节数组</returns>
        public override byte[] Serialize<T>(T item)
        {
            var type = item.GetType();
            if (!IsHaveProtoContract(type))
            {
                return base.Serialize(item);
            }
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, item);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 异步序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="item">对象值</param>
        /// <returns>字节数组</returns>
        public override Task<byte[]> SerializeAsync<T>(T item)
        {
            return Task.Factory.StartNew(() => Serialize(item));
        }

        private bool IsHaveProtoContract(Type type)
        {
            RuntimeTypeHandle typeHandle = type.TypeHandle;
            if (!_isHaveProtoContractCache.ContainsKey(typeHandle))
            {
                _isHaveProtoContractCache[typeHandle] = type.IsDefined<ProtoContractAttribute>(false);
            }
            return _isHaveProtoContractCache[typeHandle];
        }
    }
}