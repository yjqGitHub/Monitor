using MongoDB.Bson;
using Monitor.Domain.ValueObject;

namespace Monitor.TransDto.Admin
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/19 15:04:05
    /// </summary>
    public class AdminDto
    {
        /// <summary>
        /// 管理员ID
        /// </summary>
        public ObjectId AdminId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 上次登陆信息
        /// </summary>
        public LoginLog LastLoginInfo { get; set; }
    }
}