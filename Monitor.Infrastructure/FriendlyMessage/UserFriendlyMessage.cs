namespace Monitor.Infrastructure.FriendlyMessage
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：UserFriendMessage.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：UserFriendMessage
    /// 创建标识：yjq 2017/6/18 20:49:57
    /// </summary>
    public partial class FriendlyMessage
    {
        /// <summary>
        /// 用户不存在
        /// </summary>
        public const string USER_NOT_EXIT = "该用户不存在";

        /// <summary>
        /// 账户未激活
        /// </summary>
        public const string USER_NOT_ACTIVE = "账户未激活";

        /// <summary>
        /// 账户已禁用
        /// </summary>
        public const string USER_DISABLED = "账户已禁用";

        /// <summary>
        /// 用户或密码错误
        /// </summary>
        public const string USER_OR_PWD_ERROR = "用户或密码错误";

        /// <summary>
        /// 密码错误次数超出限制提示
        /// </summary>
        public const string USER_OR_ERROR_OVER_LIMIT = "由于密码错误次数过多,您的账号已被锁定,请联系管理员";
    }
}