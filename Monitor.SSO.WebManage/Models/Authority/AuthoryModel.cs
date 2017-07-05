using System.ComponentModel.DataAnnotations;

namespace Monitor.SSO.WebManage.Models
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AuthoryModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：授权用户请求信息
    /// 创建标识：yjq 2017/7/4 19:30:32
    /// </summary>
    public class AuthoryModel
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
        [StringLength(6, ErrorMessage = "请输入正确的验证码")]
        public string Code { get; set; }

        /// <summary>
        /// AppId
        /// </summary>
        [Required(ErrorMessage = "站点Id不能为空")]
        public string AppId { get; set; }
    }
}