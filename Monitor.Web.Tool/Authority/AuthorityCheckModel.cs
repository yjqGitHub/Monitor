using JQ.Extensions;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "AppId不能为空")]
        public string AppId { get; set; }

        /// <summary>
        /// 签名信息
        /// </summary>
        [Required(ErrorMessage = "签名信息不能为空")]
        public string Sign { get; set; }

        /// <summary>
        /// 授权信息
        /// </summary>
        [Required(ErrorMessage = "授权信息不能为空")]
        public string Token { get; set; }

        /// <summary>
        /// 请求时间戳
        /// </summary>
        [Required(ErrorMessage = "时间戳不能为空")]
        public long TimeTicket { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Required(ErrorMessage = "版本号不能为空")]
        public string Version { get; set; }

        /// <summary>
        /// 设置签名
        /// </summary>
        /// <param name="appSecret">密钥</param>
        public void SetSign(string appSecret)
        {
            var signData = this.ToDictionary().RemoveKey("Sign").AddOrUpdate("AppSecret", appSecret);
            Sign = signData.GetSortedContent().ToMd5();
        }

        /// <summary>
        /// 检验签名
        /// </summary>
        /// <param name="appSecret">密钥</param>
        /// <returns>签名正确返回true</returns>
        public bool CheckSign(string appSecret)
        {
            var signData = this.ToDictionary().RemoveKey("Sign").AddOrUpdate("AppSecret", appSecret);
            var sign = signData.GetSortedContent().ToMd5();
            return string.Equals(sign, Sign);
        }
    }
}