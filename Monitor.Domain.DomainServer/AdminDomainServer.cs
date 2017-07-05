using JQ;
using JQ.Extensions;
using JQ.ParamterValidate;
using JQ.Utils;
using Monitor.Domain.IDomainServer;
using Monitor.Domain.IRepository;
using Monitor.Domain.Model;
using Monitor.Domain.ValueObject;
using Monitor.ICache;
using Monitor.Infrastructure.FriendlyMessage;
using System.Threading.Tasks;

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
        private readonly IAuthorityCache _authorityCache;
        private readonly ILoginRecordRepository _loginRecordRepository;

        public AdminDomainServer(IAdminRepository adminRepository, ILoginRecordRepository loginRecordRepository, IAuthorityCache authorityCache)
        {
            _adminRepository = adminRepository;
            _loginRecordRepository = loginRecordRepository;
            _authorityCache = authorityCache;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="sitePort">登录站点</param>
        /// <returns>登录成功则返回用户信息</returns>
        public async Task<AdminInfo> LoginAsync(string userName, string pwd, SitePort sitePort)
        {
            var adminInfo = await _adminRepository.GetInfoAsync(m => m.IsDeleted == false && m.UserName == userName.Trim());
            LoginCheck(adminInfo, pwd);
            adminInfo.ChangeLastLoginInfo(sitePort);
            _adminRepository.UpdateOne(m => m.AdminId == adminInfo.AdminId, new { LastLoginInfo = adminInfo.LastLoginInfo });
            await _loginRecordRepository.InsertOneAsync(new LoginRecordInfo()
            {
                AdminId = adminInfo.AdminId,
                LoginLogInfo = adminInfo.LastLoginInfo
            });
            return adminInfo;
        }

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        public void LoginCheck(AdminInfo adminInfo, string pwd)
        {
            adminInfo.NotNull(FriendlyMessage.USER_NOT_EXIT);
            CheckCanLogin(adminInfo);
            CheckPwd(adminInfo, pwd);
        }

        public void CheckCanLogin(AdminInfo adminInfo)
        {
            switch (adminInfo.State)
            {
                case AdminState.NotActive:
                    throw new JQException(FriendlyMessage.USER_NOT_ACTIVE);
                case AdminState.Disabled:
                    throw new JQException(FriendlyMessage.USER_DISABLED);
                default: break;
            }
            //获取尝试登录的失败次数
            var tryLoginErrorCount = _authorityCache.GetLoginFailedCount(adminInfo.UserName);
            if (tryLoginErrorCount >= 5)
            {
                LogUtil.Info($"{adminInfo.UserName}:{FriendlyMessage.USER_OR_ERROR_OVER_LIMIT}");
                throw new JQException(FriendlyMessage.USER_OR_ERROR_OVER_LIMIT);
            }
        }

        /// <summary>
        /// 密码校验
        /// </summary>
        /// <param name="adminInfo">管理员信息</param>
        /// <param name="pwd">输入的登录密码</param>
        public void CheckPwd(AdminInfo adminInfo, string pwd)
        {
            string loginPwd = string.Concat(pwd, adminInfo.PwdSalt).ToMd5();
            if (!adminInfo.Pwd.Equals(loginPwd))
            {
                //设置尝试登录失败次数
                _authorityCache.AddLoginFailedCount(adminInfo.UserName);
                throw new JQException(FriendlyMessage.USER_OR_PWD_ERROR);
            }
        }
    }
}