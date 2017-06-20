using JQ.Extensions;
using JQ.Web;
using System;

namespace Monitor.Infrastructure.Helper
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：WebCommonTool.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：站点公共帮助类
    /// 创建标识：yjq 2017/6/20 17:33:12
    /// </summary>
    public sealed class WebCommonTool
    {
        private WebCommonTool()
        {
        }

        #region 验证码

        private const string _ValidateCodeCookieKey = "Monitor.ValidateCode";
        private const string _ValidateCodeSalt = "Monitor.ValidateCodeSalt";

        /// <summary>
        /// 设置验证码
        /// </summary>
        /// <param name="codeValue">验证码值</param>
        /// <param name="key">验证码key</param>
        public static void SetCode(string codeValue, string key = null)
        {
            CookieHelper.SetCookie(key ?? _ValidateCodeCookieKey, (codeValue + _ValidateCodeSalt).ToMd5(), DateTime.Now.AddMinutes(2));
        }

        /// <summary>
        /// 检验验证码是否正确
        /// </summary>
        /// <param name="codeValue">验证码值</param>
        /// <param name="key">验证码key</param>
        /// <returns>正确返回true</returns>
        public static bool CheckCode(string codeValue, string key = null)
        {
            string savedCodeValue = CookieHelper.GetCookieValue(key ?? _ValidateCodeCookieKey);
            if (codeValue.IsNullOrWhiteSpace())
            {
                return false;
            }
            return string.Equals(savedCodeValue, (codeValue + _ValidateCodeSalt).ToMd5());
        }

        #endregion 验证码

        private const string _LoginUserProviderKey = "";

        public static void CurrentLoginUser<T>(T userInfo)
        {

        }
    }
}