using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JQ.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DESProviderUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：DES加解密工具类
    /// 创建标识：yjq 2017/6/20 17:29:49
    /// </summary>
    public static class DESProviderUtil
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sourceBytes">要加密的字节数组</param>
        /// <param name="key">加密密钥</param>
        /// <returns>加密后的字节数组</returns>
        public static byte[] Encode(byte[] sourceBytes, string key)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            string providerKey = GetProviderKey(key);
            provider.Key = Encoding.ASCII.GetBytes(providerKey);
            provider.IV = Encoding.ASCII.GetBytes(providerKey);
            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream cryStream = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryStream.Write(sourceBytes, 0, sourceBytes.Length);
                    cryStream.FlushFinalBlock();
                    return stream.ToArray();
                }
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sourceBytes">要解密的字节数组</param>
        /// <param name="key">解密密钥</param>
        /// <returns>解密后的字节数组</returns>
        public static byte[] Decode(byte[] sourceBytes, string key)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            string providerKey = GetProviderKey(key);
            provider.Key = Encoding.ASCII.GetBytes(providerKey);
            provider.IV = Encoding.ASCII.GetBytes(providerKey);
            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream cryStream = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryStream.Write(sourceBytes, 0, sourceBytes.Length);
                    cryStream.FlushFinalBlock();
                    return stream.ToArray();
                }
            }
        }

        /// <summary>
        /// 获取ProviderKey的值
        /// </summary>
        /// <param name="key">密钥</param>
        /// <returns>ProviderKey的值</returns>
        private static string GetProviderKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key) || key.Length < 8) return "01234567";
            return key.Substring(0, 8);
        }
    }
}