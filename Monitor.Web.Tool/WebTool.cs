using JQ.Extensions;
using JQ.Utils;
using JQ.Web;
using MongoDB.Bson;
using Monitor.TransDto.Admin;
using System;

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

        private const string _ValidateCodeCookieKey = "Monitor.ValidateCode";

        //todo 改为动态配置
        private const string _ValidateCodeSalt = "Monitor.ValidateCodeSalt";

        /// <summary>
        /// 设置验证码
        /// </summary>
        /// <param name="codeValue">验证码值</param>
        public static void SetCode(string codeValue)
        {
            CookieHelper.SetCookie(_ValidateCodeCookieKey, (codeValue + _ValidateCodeSalt).ToMd5(), DateTime.Now.AddMinutes(2));
        }

        /// <summary>
        /// 检验验证码是否正确
        /// </summary>
        /// <param name="codeValue">验证码值</param>
        /// <returns>正确返回true</returns>
        public static bool CheckCode(string codeValue)
        {
            string savedCodeValue = CookieHelper.GetCookieValue(_ValidateCodeCookieKey);
            if (codeValue.IsNullOrWhiteSpace())
            {
                return false;
            }
            return string.Equals(savedCodeValue, (codeValue + _ValidateCodeSalt).ToMd5());
        }

        #endregion 验证码

        #region 用户Cookie设置 todo 将改为设置一个sign在前端，利用sign在缓存获取当前登录用户信息

        //todo 改为动态配置
        private const string _LoginUserProviderKey = "Monitor.CurrentUser";

        private const string _LoginUserCookiecKey = "Monitor_CurrentUser";
        private const string _LoginUserSignCookieKey = "Monitor_CurrentUser_Sign";

        //todo 改为动态配置
        private const string _LoginUserSignSalt = "Monitor_CurrentUser_Sign";

        /// <summary>
        /// 用户Cookie设置
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public static void SetCurrentLoginUser(AdminDto userInfo)
        {
            if (userInfo == null) return;
            var userBytes = userInfo.AdminId.ToString().ToBytes();
            var encodeBytes = DESProviderUtil.Encode(userBytes, _LoginUserProviderKey);
            var userStr = encodeBytes.ToStr();
            CookieHelper.SetCookie(_LoginUserCookiecKey, userStr);
            string sign = (userStr + _LoginUserSignSalt).ToMd5();
            CookieHelper.SetCookie(_LoginUserSignCookieKey, sign);
        }

        /// <summary>
        /// 获取当前用户ID
        /// </summary>
        /// <returns>当前用户ID</returns>
        public static ObjectId GetCurrentUserId()
        {
            string sign = CookieHelper.GetCookieValue(_LoginUserSignCookieKey);
            string userStr = CookieHelper.GetCookieValue(_LoginUserCookiecKey);
            string checkSign = (userStr + _LoginUserSignSalt).ToMd5();
            if (sign.Equals(checkSign))
            {
                var encodeUserBytes = userStr.ToBytes();
                var userBytes = DESProviderUtil.Decode(encodeUserBytes, _LoginUserProviderKey);
                ObjectId userId;
                if (ObjectId.TryParse(userBytes.ToStr(), out userId))
                {
                    return userId;
                }
            }
            return ObjectId.Empty;
        }

        #endregion 用户Cookie设置 todo 将改为设置一个sign在前端，利用sign在缓存获取当前登录用户信息
    }
}