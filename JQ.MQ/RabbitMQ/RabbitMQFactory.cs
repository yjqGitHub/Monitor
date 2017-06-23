using JQ.MQ.Serialization;

namespace JQ.MQ.RabbitMQ
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：RabbitMQFactory.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RabbitMQFactory
    /// 创建标识：yjq 2017/6/11 23:01:39
    /// </summary>
    public sealed class RabbitMQFactory : IMQFactory
    {
        private readonly IMQBinarySerializer _binarySerializer;

        public RabbitMQFactory(IMQBinarySerializer binarySerializer)
        {
            _binarySerializer = binarySerializer;
        }

        /// <summary>
        /// 创建一个RabbitMq客户端
        /// </summary>
        /// <param name="mqConfig">mq配置信息</param>
        /// <returns>RabbitMq客户端</returns>
        public IMQClient Create(MQConfig mqConfig)
        {
            return new RabbitMQClient(mqConfig, _binarySerializer);
        }
    }
}