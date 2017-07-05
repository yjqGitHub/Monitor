using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Monitor.Domain.ValueObject;
using System;

namespace Monitor.Domain.Model
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AuthorityInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：授权信息
    /// 创建标识：yjq 2017/7/5 15:09:05
    /// </summary>
    public class AuthorityInfo : IAggregateRoot
    {
        public AuthorityInfo()
        {
            AuthorityId = ObjectId.GenerateNewId();
            AuthorityTime = DateTime.Now;
            IsDeleted = false;
            CreateTime = DateTime.Now;
            State = AuthorityState.Authoritied;
        }

        public AuthorityInfo(ObjectId adminId, string token) : this()
        {
            AdminId = adminId;
            AuthorityToken = token;
        }

        /// <summary>
        /// 授权记录ID
        /// </summary>
        [BsonElement(elementName: "_id")]
        public ObjectId AuthorityId { get; set; }

        /// <summary>
        /// 授权用户ID
        /// </summary>
        public ObjectId AdminId { get; set; }

        /// <summary>
        /// 授权Token
        /// </summary>
        public string AuthorityToken { get; set; }

        /// <summary>
        /// 授权状态
        /// </summary>
        public AuthorityState State { get; set; }

        /// <summary>
        /// 授权时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime AuthorityTime { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? InvalidTime { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? LastModifyTime { get; set; }
    }
}