using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Monitor.Domain.ValueObject;

namespace Monitor.Domain.Model
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：LoginRecordInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：登录记录
    /// 创建标识：yjq 2017/6/18 16:56:51
    /// </summary>
    public class LoginRecordInfo : IAggregateRoot
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        [BsonElement(elementName: "_id")]
        public ObjectId RecordId { get; set; }

        /// <summary>
        /// 管理员ID
        /// </summary>
        public ObjectId AdminId { get; set; }

        /// <summary>
        /// 登录信息
        /// </summary>
        public LoginLog LoginLogInfo { get; set; }
    }
}