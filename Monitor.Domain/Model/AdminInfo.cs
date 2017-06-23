using JQ.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Monitor.Domain.ValueObject;
using System;
using System.Collections.Generic;

namespace Monitor.Domain.Model
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AdminInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员信息
    /// 创建标识：yjq 2017/6/18 16:28:00
    /// </summary>
    public class AdminInfo : IAggregateRoot
    {
        public AdminInfo()
        {
            AdminId = ObjectId.GenerateNewId();
        }

        /// <summary>
        /// 管理员ID
        /// </summary>
        [BsonElement(elementName: "_id")]
        public ObjectId AdminId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 密码盐值
        /// </summary>
        public string PwdSalt { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public AdminState State { get; set; }

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

        /// <summary>
        /// 上次登陆信息
        /// </summary>
        public LoginLog LastLoginInfo { get; set; }

        /// <summary>
        /// 登录记录
        /// </summary>
        [BsonIgnore]
        public virtual List<LoginRecordInfo> LoginRecords { get; set; }

        /// <summary>
        /// 更改上次登录信息
        /// </summary>
        /// <param name="sitePort">登录站点</param>
        public void ChangeLastLoginInfo(SitePort sitePort)
        {
            this.LastLoginInfo = new LoginLog(DateTime.Now, WebUtil.GetRealIP(), sitePort, WebUtil.GetUserAgent());
        }
    }
}