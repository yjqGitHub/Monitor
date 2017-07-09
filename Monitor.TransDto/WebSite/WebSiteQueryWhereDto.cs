using Monitor.Domain.ValueObject;

namespace Monitor.TransDto.WebSite
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：WebSiteQueryWhereDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：WebSiteQueryWhereDto
    /// 创建标识：yjq 2017/7/9 22:27:25
    /// </summary>
    public class WebSiteQueryWhereDto : BasePageQueryWhereDto
    {
        /// <summary>
        /// 站点的AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 站点名字
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// 站点状态
        /// </summary>
        public SiteState? State { get; set; }

    }
}