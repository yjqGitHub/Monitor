namespace Monitor.SSO.WebManage.Models
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：WebSiteReuqestModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：WebSiteReuqestModel
    /// 创建标识：yjq 2017/7/1 14:42:38
    /// </summary>
    public class WebSiteReuqestModel
    {
        /// <summary>
        /// 站点AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 签名信息
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 返回地址
        /// </summary>
        public string BackUrl { get; set; }
    }
}