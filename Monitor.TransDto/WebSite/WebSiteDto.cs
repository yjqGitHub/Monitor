using MongoDB.Bson;
using Monitor.Domain.ValueObject;

namespace Monitor.TransDto.WebSite
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：WebSiteDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/4 10:29:33
    /// </summary>
    public sealed class WebSiteDto
    {
        /// <summary>
        /// 站点ID
        /// </summary>
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
    }
}