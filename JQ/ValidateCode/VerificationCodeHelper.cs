using JQ.Configurations;
using JQ.Extensions;
using JQ.Web;
using System;

namespace JQ.ValidateCode
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：VerificationCodeHelper.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：VerificationCodeHelper
    /// 创建标识：yjq 2017/6/10 23:10:19
    /// </summary>
    public static class VerificationCodeHelper
    {
        /// <summary>
        /// 设置验证码
        /// </summary>
        /// <param name="codeValue">验证码值</param>
        /// <param name="key">验证码key</param>
        public static void SetCode(string codeValue, string key = null)
        {
            CookieHelper.SetCookie(key ?? JQConfiguration.Instance.ValidateCodeCookieKey, (codeValue + JQConfiguration.Instance.ValidateCodeSalt).ToMd5(), DateTime.Now.AddMinutes(2));
        }

        /// <summary>
        /// 检验验证码是否正确
        /// </summary>
        /// <param name="codeValue">验证码值</param>
        /// <param name="key">验证码key</param>
        /// <returns>正确返回true</returns>
        public static bool CheckCode(string codeValue, string key = null)
        {
            string savedCodeValue = CookieHelper.GetCookieValue(key ?? JQConfiguration.Instance.ValidateCodeCookieKey);
            if (codeValue.IsNullOrWhiteSpace())
            {
                return false;
            }
            return string.Equals(savedCodeValue, (codeValue + JQConfiguration.Instance.ValidateCodeSalt).ToMd5());
        }
    }
}