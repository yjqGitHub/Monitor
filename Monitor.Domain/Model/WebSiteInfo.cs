using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Monitor.Domain.ValueObject;
using System;

namespace Monitor.Domain.Model
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：WebSiteInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：站点信息
    /// 创建标识：yjq 2017/7/1 14:50:03
    /// </summary>
    public class WebSiteInfo : IAggregateRoot
    {
        public WebSiteInfo()
        {
            WebSiteId = ObjectId.GenerateNewId();
        }

        /// <summary>
        /// 站点ID
        /// </summary>
        [BsonElement(elementName: "_id")]
        public ObjectId WebSiteId { get; set; }

        /// <summary>
        /// 站点的AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 站点密钥
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 站点名字
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// 站点标题
        /// </summary>
        public string SiteTitle { get; set; }

        /// <summary>
        /// 站点基础地址
        /// </summary>
        public string SiteHost { get; set; }

        /// <summary>
        /// 站点图片
        /// </summary>
        public string SiteImageUrl { get; set; }

        /// <summary>
        /// 站点默认返回地址
        /// </summary>
        public string SiteDefaultBackUrl { get; set; }

        /// <summary>
        /// 站点状态
        /// </summary>
        public SiteState State { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 添加人
        /// </summary>
        public ObjectId CreateUserId { get; set; }

        /// <summary>
        /// 上次修改时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 上次修改人
        /// </summary>
        public ObjectId? LastModifyUserId { get; set; }
    }
}