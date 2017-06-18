using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Monitor.Domain.ValueObject
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：LoginInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：登录信息
    /// 创建标识：yjq 2017/6/18 16:35:47
    /// </summary>
    public class LoginLog
    {
        /// <summary>
        /// 登录时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LoginTime { get; private set; }

        /// <summary>
        /// 登录Ip
        /// </summary>
        public string LoginIp { get; private set; }

        /// <summary>
        /// 登录地址
        /// </summary>
        public string LoginAddress { get; private set; }

        /// <summary>
        /// 登录端口
        /// </summary>
        public SitePort LoginSitePort { get; private set; }

        /// <summary>
        /// 登录端口信息
        /// </summary>
        public string LoginUserAgent { get; private set; }
    }
}