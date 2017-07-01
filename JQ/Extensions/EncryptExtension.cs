using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace JQ.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：EncryptExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：加解密扩展类
    /// 创建标识：yjq 2017/6/10 23:07:36
    /// </summary>
    public static partial class EncryptExtension
    {
        #region 将字节数组转为md5加密后的字符信息

        /// <summary>
        /// 将字节数组转为md5加密后的字符信息
        /// </summary>
        /// <param name="input">要加密的字节数组</param>
        /// <returns>加密后的md5信息</returns>
        public static string ToMd5(this byte[] input, string defaultFormat = "x2")
        {
            StringBuilder hashBuilder = new StringBuilder();
            MD5 md5 = MD5.Create();
            md5.ComputeHash(input).ForEach(b =>
            {
                hashBuilder.AppendFormat("{0:" + defaultFormat + "}", b);
            });
            return hashBuilder.ToString();
        }

        #endregion 将字节数组转为md5加密后的字符信息

        #region 将字符转为md5加密后的字符信息

        /// <summary>
        /// 将字符转为md5加密后的字符信息
        /// </summary>
        /// <param name="input">要加密的字符信息</param>
        /// <returns>加密后的md5信息</returns>
        public static string ToMd5(this string input, string defaultFormat = "x2")
        {
            return input.ToMd5(Encoding.UTF8, defaultFormat: defaultFormat);
        }

        /// <summary>
        /// 将字符转为md5加密后的字符信息
        /// </summary>
        /// <param name="input">要加密的字符信息</param>
        /// <param name="encode">加密编码格式</param>
        /// <returns>加密后的md5信息</returns>
        public static string ToMd5(this string input, Encoding encode, string defaultFormat = "x2")
        {
            if (input.IsNullOrWhiteSpace()) return string.Empty;
            if (encode == null) return string.Empty;
            return encode.GetBytes(input).ToMd5(defaultFormat: defaultFormat);
        }

        #endregion 将字符转为md5加密后的字符信息

        #region base64加解密

        #region 将字符串转为base64字符串

        /// <summary>
        /// 将字符串转为base64字符串
        /// </summary>
        /// <param name="input">要转化的字符串</param>
        /// <param name="encode">编码格式默认Utf8</param>
        /// <returns>base64字符串</returns>
        public static string ToBase64(this string input, Encoding encode = null)
        {
            if (input.IsNullOrWhiteSpace()) return string.Empty;
            if (encode == null)
            {
                encode = Encoding.UTF8;
            };
            return Convert.ToBase64String(encode.GetBytes(input));
        }

        /// <summary>
        /// 将字节数组转为base64字符串
        /// </summary>
        /// <param name="input">要转化的字节数组</param>
        /// <returns>base64字符串</returns>
        public static string ToBase64(this byte[] input)
        {
            if (input != null) return string.Empty;
            return Convert.ToBase64String(input);
        }

        #endregion 将字符串转为base64字符串

        #region base64字符解密

        /// <summary>
        /// base64字符解密
        /// </summary>
        /// <param name="input">需要解密的字符信息</param>
        /// <param name="encode">编码格式默认Utf8</param>
        /// <returns>解密后的字符信息</returns>
        public static string DecodeBase64(this string input, Encoding encode)
        {
            if (input.IsNullOrWhiteSpace()) return string.Empty;
            if (encode == null)
            {
                encode = Encoding.UTF8;
            };
            byte[] strBytes = Convert.FromBase64String(input);
            return encode.GetString(strBytes);
        }

        /// <summary>
        /// base64字符解密
        /// </summary>
        /// <param name="input">需要解密的字符信息</param>
        /// <returns>解密后的字节数组</returns>
        public static byte[] DecodeBase64(this string input)
        {
            if (input.IsNullOrWhiteSpace()) return null;
            return Convert.FromBase64String(input); ;
        }

        #endregion base64字符解密

        #endregion base64加解密

        #region 对字符串进行Url加密

        /// <summary>
        /// 对字符串进行Url加密
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <param name="encodeName">加密编码格式</param>
        /// <returns>Url加密后的字符</returns>
        public static string UrlEncode(this string str, string encodeName)
        {
            return HttpUtility.UrlEncode(str, Encoding.GetEncoding(encodeName));
        }

        #endregion 对字符串进行Url加密

        #region 对字符串进行Url解密

        /// <summary>
        /// 对字符串进行Url解密
        /// </summary>
        /// <param name="str">需要解密的字符串</param>
        /// <param name="decodeName">解密编码格式</param>
        /// <returns>Url解密后的字符串</returns>
        public static string UrlDecode(this string str, string decodeName)
        {
            return HttpUtility.UrlDecode(str, Encoding.GetEncoding(decodeName));
        }

        #endregion 对字符串进行Url解密
    }
}