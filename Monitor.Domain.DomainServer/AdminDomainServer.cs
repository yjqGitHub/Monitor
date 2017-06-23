using JQ;
using JQ.Extensions;
using JQ.ParamterValidate;
using JQ.Redis;
using Monitor.Domain.IDomainServer;
using Monitor.Domain.IRepository;
using Monitor.Domain.Model;
using Monitor.Domain.ValueObject;
using Monitor.Infrastructure.FriendlyMessage;
using Monitor.Infrastructure.Redis;
using System;

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
            var tryLoginErrorCount = RedisHelper.GetClient().StringGet<long>(string.Format(RedisKeyConstant.REDIS_KEY_LOGINERROR_COUNT_BASE, adminInfo.UserName));
            if (tryLoginErrorCount >= 5)
            {
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
                RedisHelper.GetClient().SetAndSetExpireTime(string.Format(RedisKeyConstant.REDIS_KEY_LOGINERROR_COUNT_BASE, adminInfo.UserName), expireTimeSpan: TimeSpan.FromMinutes(1), setAction: (redisClient, key) =>
                {
                    redisClient.StringIncrement(key);
                });
                throw new JQException(FriendlyMessage.USER_OR_PWD_ERROR);
            }
        }
    }
}