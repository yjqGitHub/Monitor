using Monitor.Domain.ValueObject;
using System;
using System.ComponentModel.DataAnnotations;

namespace Monitor.SSO.WebManage.Models
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：WebSiteModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：WebSiteModel
    /// 创建标识：yjq 2017/7/10 14:07:50
    /// </summary>
    public class WebSiteModel
    {
        /// <summary>
        /// 站点ID
        /// </summary>
        public string WebSiteId { get; set; }

        /// <summary>
        /// 站点的AppId
        /// </summary>
        [Required(ErrorMessage = "AppId不能为空")]
        public string AppId { get; set; }

        /// <summary>
        /// 站点密钥
        /// </summary>
        [Required(ErrorMessage = "密钥不能为空")]
        public string AppSecret { get; set; }

        /// <summary>
        /// 站点名字
        /// </summary>
        [Required(ErrorMessage = "名字不能为空")]
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
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 上次修改时间
        /// </summary>

        public DateTime? LastModifyTime { get; set; }
    }
}