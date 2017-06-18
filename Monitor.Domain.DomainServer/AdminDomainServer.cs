using JQ.Extensions;
using JQ.ParamterValidate;
using Monitor.Domain.IDomainServer;
using Monitor.Domain.IRepository;
using Monitor.Domain.Model;
using Monitor.Infrastructure.FriendMessage;

namespace Monitor.Domain.DomainServer
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AdminDomainServer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AdminDomainServer
    /// 创建标识：yjq 2017/6/18 20:28:29
    /// </summary>
    public sealed class AdminDomainServer : IAdminDomainServer
    {
        private readonly IAdminRepository _adminRepository;

        public AdminDomainServer(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        public void LoginCheck(AdminInfo adminInfo, string pwd)
        {
            adminInfo.NotNull(FriendMessage.USER_OR_PWD_ERROR);
            adminInfo.CheckCanLogin();
            CheckPwd(adminInfo, pwd);
        }

        /// <summary>
        /// 密码校验
        /// </summary>
        /// <param name="adminInfo">管理员信息</param>
        /// <param name="pwd">输入的登录密码</param>
        public void CheckPwd(AdminInfo adminInfo, string pwd)
        {
            string loginPwd = string.Concat(pwd, adminInfo.PwdSalt).ToMd5();
            adminInfo.Pwd.Equal(loginPwd, FriendMessage.USER_OR_PWD_ERROR);
        }
    }
}