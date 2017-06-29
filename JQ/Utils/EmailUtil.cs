using JQ.Extensions;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JQ.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：EmailUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：邮件帮助类
    /// 创建标识：yjq 2017/6/29 13:12:44
    /// </summary>
    public static class EmailUtil
    {
        #region 发送邮件

        /// <summary>
        /// 发送邮件(smtp协议)
        /// </summary>
        /// <param name="to">接收人</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <param name="serviceMailAddress">服务器邮箱账号</param>
        /// <param name="serviceMailPwd">服务器邮箱密码</param>
        /// <returns></returns>
        public static void SendEmail(string to, string subject, string content, string serviceMailAddress, string serviceMailPwd)
        {
            SendEmail(new string[] { to }, subject, content, serviceMailAddress, serviceMailPwd);
        }

        /// <summary>
        /// 发送邮件(smtp协议)
        /// </summary>
        /// <param name="to">接收人</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <param name="serviceMailAddress">服务器邮箱账号</param>
        /// <param name="serviceMailPwd">服务器邮箱密码</param>
        /// <returns></returns>
        public static async Task SendEmailAsync(string to, string subject, string content, string serviceMailAddress, string serviceMailPwd)
        {
            await SendEmailAsync(new string[] { to }, subject, content, serviceMailAddress, serviceMailPwd);
        }

        /// <summary>
        /// 发送邮件(smtp协议)
        /// </summary>
        /// <param name="toList">接收人列表</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <param name="serviceMailAddress">服务器邮箱账号</param>
        /// <param name="serviceMailPwd">服务器邮箱密码</param>
        /// <returns></returns>
        public static async Task SendEmailAsync(string[] toList, string subject, string content, string serviceMailAddress, string serviceMailPwd)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(serviceMailAddress);
            toList.ForEach(to =>
            {
                mail.To.Add(new MailAddress(to));
            });
            mail.Subject = subject;
            mail.Body = content;
            mail.BodyEncoding = Encoding.UTF8;
            SmtpClient client = new SmtpClient("smtp.163.com", 25);
            client.Timeout = 9999;
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(serviceMailAddress, serviceMailPwd);
            try
            {
                await client.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, memberName: "EmailUtil-SendEmailAsync");
            }
        }

        /// <summary>
        /// 发送邮件(smtp协议)
        /// </summary>
        /// <param name="toList">接收人列表</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <param name="serviceMailAddress">服务器邮箱账号</param>
        /// <param name="serviceMailPwd">服务器邮箱密码</param>
        public static void SendEmail(string[] toList, string subject, string content, string serviceMailAddress, string serviceMailPwd)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(serviceMailAddress);
            toList.ForEach(to =>
            {
                mail.To.Add(new MailAddress(to));
            });
            mail.Subject = subject;
            mail.Body = content;
            mail.BodyEncoding = Encoding.UTF8;
            SmtpClient client = new SmtpClient("smtp.163.com", 25);
            client.Timeout = 9999;
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(serviceMailAddress, serviceMailPwd);
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, memberName: "EmailUtil-SendEmail");
            }
        }

        #endregion 发送邮件
    }
}