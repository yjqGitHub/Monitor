namespace Monitor.Web.Tool.Authority
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AuthorityCheckModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：授权认证MOdel
    /// 创建标识：yjq 2017/7/1 15:54:43
    /// </summary>
    public class AuthorityCheckModel
    {
        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 签名信息
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 授权信息
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 请求时间戳
        /// </summary>
        public long TimeTicket { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
    }
}