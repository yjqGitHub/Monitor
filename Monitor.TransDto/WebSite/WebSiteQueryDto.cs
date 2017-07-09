using Monitor.Domain.ValueObject;
using System;

namespace Monitor.TransDto.WebSite
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：WebSiteQueryDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：列表查询对象
    /// 创建标识：yjq 2017/7/9 17:43:56
    /// </summary>
    public class WebSiteQueryDto
    {
        /// <summary>
        /// 站点ID
        /// </summary>
        public string WebSiteId { get; set; }

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
        /// 站点状态
        /// </summary>
        public SiteState State { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 上次修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
    }
}