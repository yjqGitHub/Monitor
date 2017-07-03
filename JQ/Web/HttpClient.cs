using JQ.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace JQ.Web
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：HttpClient.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：http请求帮助类
    /// 创建标识：yjq 2017/7/3 15:32:22
    /// </summary>
    public sealed class HttpClient
    {
        private string _url = null;
        private int _connectTimeout = 30000;
        private int _readTimeOut = 30000;
        private string _charset = "UTF-8";
        private string _contentType = "application/x-www-form-urlencoded";
        private static readonly string _DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        public HttpClient(string url)
        {
            _url = url;
        }

        public HttpClient(string url, int cTimeOut, int rTimeOut)
            : this(url)
        {
            _connectTimeout = cTimeOut;
            _readTimeOut = rTimeOut;
        }

        #region public Property

        /// <summary>
        /// 编码格式
        /// </summary>
        public string Charset
        {
            get { return _charset; }
            set { _charset = value; }
        }

        /// <summary>
        /// 请求体格式
        /// </summary>
        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string CurrentUri
        {
            get { return _url; }
        }

        /// <summary>
        /// 请求链接超时时间
        /// </summary>
        public int ConnectTimeout
        {
            get { return _connectTimeout; }
        }

        /// <summary>
        /// 读取超时时间
        /// </summary>
        public int ReadTimeOut
        {
            get { return _readTimeOut; }
        }

        #endregion public Property

        #region 获取一个http请求连接

        /// <summary>
        /// 获取一个http请求连接
        /// </summary>
        /// <returns></returns>
        public HttpWebRequest GetConnection()
        {
            HttpWebRequest requestConn = null;

            if (CurrentUri.StartsWith("Https", StringComparison.OrdinalIgnoreCase))//Https 请求
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                requestConn = WebRequest.Create(CurrentUri) as HttpWebRequest;
                requestConn.ProtocolVersion = HttpVersion.Version10;
            }
            else//http 请求
            {
                requestConn = WebRequest.Create(CurrentUri) as HttpWebRequest;
            }
            requestConn.Timeout = ConnectTimeout;
            requestConn.ReadWriteTimeout = ReadTimeOut;
            requestConn.ContentType = string.Format("{0};charset={1}", ContentType, Charset);
            requestConn.UserAgent = _DefaultUserAgent;
            return requestConn;
        }

        #endregion 获取一个http请求连接

        #region 根据请求地址获取返回流

        /// <summary>
        /// 根据请求地址获取返回流
        /// </summary>
        /// <returns></returns>
        public MemoryStream GetWebStream()
        {
            HttpWebRequest requestConnection = GetConnection();
            HttpWebResponse response = null;
            Stream receiveStream = null;
            try
            {
                requestConnection.Method = "Get";
                response = requestConnection.GetResponse() as HttpWebResponse;
                receiveStream = response.GetResponseStream();
                MemoryStream stream = new MemoryStream();
                receiveStream.CopyTo(stream);
                return stream;
            }
            finally
            {
                receiveStream?.Dispose();
                response?.Dispose();
            }
        }

        #endregion 根据请求地址获取返回流

        #region 发送一个post请求

        /// <summary>
        /// 发送一个post请求
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="data">发送内容</param>
        /// <returns>返回值</returns>
        public T Post<T>(string data)
        {
            return Post(data).ToObjInfo<T>();
        }

        /// <summary>
        /// 发送一个post请求
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="data">发送内容</param>
        /// <returns>返回值</returns>
        public T Post<T>(Dictionary<string, object> data)
        {
            return Post(data).ToObjInfo<T>();
        }

        /// <summary>
        /// 发送一个post请求
        /// </summary>
        /// <param name="data">发送内容</param>
        /// <returns></returns>
        public string Post(Dictionary<string, object> data)
        {
            return Post(data.ToRequestContent(Charset));
        }

        /// <summary>
        /// 发送一个post请求
        /// </summary>
        /// <param name="data">发送内容</param>
        /// <returns></returns>
        public string Post(string data)
        {
            HttpWebRequest requestConnection = GetConnection();
            Stream outStream = null;
            Stream receiveStream = null;
            HttpWebResponse response = null;
            try
            {
                requestConnection.Method = "Post";
                outStream = requestConnection.GetRequestStream();
                SendData(outStream, data.ToBytes(Charset));
                response = requestConnection.GetResponse() as HttpWebResponse;
                receiveStream = response.GetResponseStream();
                string encoding = GetHtmlEncoding(response.ContentEncoding, defaultEncoding: Charset);
                using (StreamReader writeStrem = new StreamReader(receiveStream, Encoding.GetEncoding(encoding)))
                {
                    return writeStrem.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Post_Error", e);
            }
            finally
            {
                outStream?.Dispose();
                receiveStream?.Dispose();
                response?.Dispose();
            }
        }

        #endregion 发送一个post请求

        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受
        }

        private void SendData(Stream outStream, byte[] content)
        {
            try
            {
                outStream.Write(content, 0, content.Length);
                outStream.Flush();
            }
            catch (Exception e)
            {
                throw new Exception("snd_data_error", e);
            }
        }

        private string GetHtmlEncoding(string responseEncoding, string defaultEncoding = "UTF-8")
        {
            if (responseEncoding == null || responseEncoding.Length < 1)
            {
                return defaultEncoding;
            }
            return responseEncoding;
        }
    }
}