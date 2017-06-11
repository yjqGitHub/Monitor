using System.ComponentModel.DataAnnotations;

namespace Monitor.WebManage.Models
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AccountModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：登录
    /// 创建标识：yjq 2017/6/11 0:08:19
    /// </summary>
    public sealed class AccountModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Pwd { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "请输入验证码")]
        public string Code { get; set; }
    }
}