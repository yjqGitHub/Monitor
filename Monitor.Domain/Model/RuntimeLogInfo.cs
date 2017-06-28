using JQ.MQ.Logger;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Monitor.Domain.ValueObject;
using System;

namespace Monitor.Domain.Model
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RuntimeMessageInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：运行时日志信息
    /// 创建标识：yjq 2017/6/27 14:57:30
    /// </summary>
    public sealed class RuntimeLogInfo
    {
        public RuntimeLogInfo()
        {
            MessageId = ObjectId.GenerateNewId();
        }

        [BsonElement(elementName: "_id")]
        public ObjectId MessageId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string AppDomain { get; set; }

        /// <summary>
        /// 记录器名字
        /// </summary>
        public string LoggerName { get; set; }

        /// <summary>
        /// 日志消息类型
        /// </summary>
        public RuntimeLogType LogType { get; set; }

        /// <summary>
        /// 日志信息内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LogTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否需要预警
        /// </summary>
        public bool IsNeedWaring
        {
            get; set;
        }

        /// <summary>
        /// 是否已经处理
        /// </summary>
        public bool IsDealed { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? LastModifyTime { get; set; }

        public void SetLogType(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Debug:
                    this.LogType = RuntimeLogType.Debug;
                    break;

                case MessageType.Info:
                    this.LogType = RuntimeLogType.Info;
                    break;

                case MessageType.Error:
                    this.LogType = RuntimeLogType.Error;
                    break;

                case MessageType.Warn:
                    this.LogType = RuntimeLogType.Warn;
                    break;

                case MessageType.Fatal:
                    this.LogType = RuntimeLogType.Fatal;
                    break;
            }
        }
    }
}