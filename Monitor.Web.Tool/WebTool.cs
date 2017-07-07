using JQ.Extensions;
using JQ.Utils;
using JQ.Web;
using MongoDB.Bson;
using Monitor.TransDto.Admin;
using System;
using System.Collections.Generic;

namespace Monitor.Web.Tool
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：WebTool.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：WebTool
    /// 创建标识：yjq 2017/6/20 19:49:59
    /// </summary>
    public sealed class WebTool
    {
        #region 验证码

        private const string _VALIDATCODE_COOKIEKEY = "Monitor.ValidateCode";

        //todo 改为动态配置
        private const string _VALIDATCODE_SALT = "Monitor.ValidateCodeSalt";

        /// <summary>
        /// 设置验证码
        /// </summary>
        /// <param name="codeValue">验证码值</param>
        public static void SetCode(string codeValue)
        {
            CookieHelper.SetCookie(_VALIDATCODE_COOKIEKEY, (codeValue + _VALIDATCODE_SALT).ToMd5(), DateTime.Now.AddMinutes(2));
        }

        /// <summary>
        /// 检验验证码是否正确
        /// </summary>
        /// <param name="codeValue">验证码值</param>
        /// <returns>正确返回true</returns>
        public static bool CheckCode(string codeValue)
        {
            string savedCodeValue = CookieHelper.GetCookieValue(_VALIDATCODE_COOKIEKEY);
            if (codeValue.IsNullOrWhiteSpace())
            {
                return false;
            }
            return string.Equals(savedCodeValue, (codeValue + _VALIDATCODE_SALT).ToMd5());
        }

        #endregion 验证码

        #region 用户Cookie设置 todo 将改为设置一个sign在前端，利用sign在缓存获取当前登录用户信息

        /// <summary>
        /// 本地用户cookieKey
        /// </summary>
        private const string _CURRENTUSER_LOCAL_COOKIEKEY = "Monitor_CurrentUser_Local";

        /// <summary>
        /// 本地当前用户信息签名的CookieKey
        /// </summary>
        private const string _CURRENTUSER_SIGN_LOCAL_COOKIEKEY = "Monitor_CurrentUser_Sign_Local";

        /// <summary>
        /// 当前用户的CookieKey
        /// </summary>
        private const string _CURRENTUSER_COOKIEKEY = "Monitor_CurrentUser";

        /// <summary>
        /// 当前用户信息签名的CookieKey
        /// </summary>
        private const string _CURRENTUSER_SIGN_COOKIEKEY = "Monitor_CurrentUser_Sign";

        /// <summary>
        /// 用户信息加密的Key
        /// </summary>
        private const string _CONFIGKEY_CURRENTUSER_PROVIDERKEY = "CurrentUserProviderKey";

        /// <summary>
        /// CookieSign的加密盐值Key
        /// </summary>
        private const string _CONFIGKEY_CURRENTUSER_SIGN_SALT = "CurrentSignSalt";

        /// <summary>
        /// 用户Cookie设置
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public static void SetCurrentLoginUser(AdminDto userInfo)
        {
            if (userInfo == null) return;
            var userBytes = userInfo.AdminId.ToString().ToBytes();
            var encodeBytes = DESProviderUtil.Encode(userBytes, ConfigUtil.GetValue(_CONFIGKEY_CURRENTUSER_PROVIDERKEY));
            var userStr = encodeBytes.ToStr();
            CookieHelper.SetCookie(_CURRENTUSER_COOKIEKEY, userStr);
            string sign = (userStr + ConfigUtil.GetValue(_CONFIGKEY_CURRENTUSER_SIGN_SALT)).ToMd5();
            CookieHelper.SetCookie(_CURRENTUSER_SIGN_COOKIEKEY, sign);
        }

        /// <summary>
        /// 获取当前用户ID
        /// </summary>
        /// <returns>当前用户ID</returns>
        public static ObjectId GetCurrentUserId()
        {
            string sign = CookieHelper.GetCookieValue(_CURRENTUSER_SIGN_COOKIEKEY);
            string userStr = CookieHelper.GetCookieValue(_CURRENTUSER_COOKIEKEY);
            string checkSign = (userStr + ConfigUtil.GetValue(_CONFIGKEY_CURRENTUSER_SIGN_SALT)).ToMd5();
            if (sign.Equals(checkSign))
            {
                var encodeUserBytes = userStr.ToBytes();
                var userBytes = DESProviderUtil.Decode(encodeUserBytes, ConfigUtil.GetValue(_CONFIGKEY_CURRENTUSER_PROVIDERKEY));
                ObjectId userId;
                if (ObjectId.TryParse(userBytes.ToStr(), out userId))
                {
                    return userId;
                }
            }
            return ObjectId.Empty;
        }

        #endregion 用户Cookie设置 todo 将改为设置一个sign在前端，利用sign在缓存获取当前登录用户信息

        #region token

        /// <summary>
        /// 设置当前用户的token值
        /// </summary>
        /// <param name="token">token值</param>
        public static void SetCurrentUserToken(string token)
        {
            if (token.IsNullOrWhiteSpace()) return;
            CookieHelper.SetCookie(_CURRENTUSER_COOKIEKEY, token);
            string sign = (token + ConfigUtil.GetValue(_CONFIGKEY_CURRENTUSER_SIGN_SALT)).ToMd5();
            CookieHelper.SetCookie(_CURRENTUSER_SIGN_COOKIEKEY, sign);
        }

        /// <summary>
        /// 获取当前用户的token值
        /// </summary>
        /// <returns>token值</returns>
        public static string GetCurrentUserToken()
        {
            string sign = CookieHelper.GetCookieValue(_CURRENTUSER_SIGN_COOKIEKEY);
            string userStr = CookieHelper.GetCookieValue(_CURRENTUSER_COOKIEKEY);
            string checkSign = (userStr + ConfigUtil.GetValue(_CONFIGKEY_CURRENTUSER_SIGN_SALT)).ToMd5();
            if (sign.Equals(checkSign))
            {
                return userStr;
            }
            return string.Empty;
        }

        #endregion token

        #region 本地token

        /// <summary>
        /// 设置本地token的Cookie
        /// </summary>
        /// <param name="token">要设置的token</param>
        public static void SetSiteLocalToken(string token)
        {
            if (token.IsNullOrWhiteSpace()) return;
            CookieHelper.SetCookie(_CURRENTUSER_LOCAL_COOKIEKEY, token);
            string sign = (token + ConfigUtil.GetValue(_CONFIGKEY_CURRENTUSER_SIGN_SALT)).ToMd5();
            CookieHelper.SetCookie(_CURRENTUSER_SIGN_LOCAL_COOKIEKEY, sign);
        }

        /// <summary>
        /// 获取本地token的Cookie
        /// </summary>
        /// <returns>本地token</returns>
        public static string GetSiteLocalToken()
        {
            string sign = CookieHelper.GetCookieValue(_CURRENTUSER_SIGN_LOCAL_COOKIEKEY);
            string userStr = CookieHelper.GetCookieValue(_CURRENTUSER_LOCAL_COOKIEKEY);
            string checkSign = (userStr + ConfigUtil.GetValue(_CONFIGKEY_CURRENTUSER_SIGN_SALT)).ToMd5();
            if (sign.Equals(checkSign))
            {
                return userStr;
            }
            return string.Empty;
        }

        #endregion 本地token

        #region 获取返回地址

        /// <summary>
        /// 获取返回地址
        /// </summary>
        /// <param name="defaultBackUrl">默认返回地址</param>
        /// <param name="backUrl">返回地址</param>
        /// <param name="arguments">参数</param>
        /// <returns>返回地址</returns>
        public static string GetBackUrl(string defaultBackUrl, string backUrl, Dictionary<string, string> arguments = null)
        {
            string baseUrl = string.Empty;
            if (backUrl.IsNullOrWhiteSpace() && defaultBackUrl.IsNullOrWhiteSpace())
            {
                baseUrl = "/Home/Index";
            }
            else if (backUrl.IsNotNullAndNotWhiteSpace())
            {
                baseUrl = backUrl;
            }
            else
            {
                baseUrl = defaultBackUrl;
            }
            if (baseUrl.StartsWith("http:") || baseUrl.StartsWith("https:"))
            {
                EnhancedUriBuilder uriBuilder = new EnhancedUriBuilder(baseUrl);
                if (arguments != null)
                {
                    foreach (KeyValuePair<string, string> item in arguments)
                    {
                        uriBuilder.QueryItems[item.Key] = item.Value;
                    }
                }
                return uriBuilder.ToString();
            }
            else
            {
                string queryItem = string.Empty;
                if (arguments != null)
                {
                    foreach (KeyValuePair<string, string> item in arguments)
                    {
                        queryItem += item.Key + "=" + item.Value.UrlEncode("UTF-8") + "&";
                    }
                    if (queryItem.Length > 0)
                    {
                        queryItem.Substring(0, queryItem.Length - 1);
                    }
                }
                if (baseUrl.IndexOf('?') > 0)
                {
                    return baseUrl + queryItem;
                }
                else
                {
                    return baseUrl + "?" + queryItem;
                }
            }
        }

        #endregion 获取返回地址
    }
}