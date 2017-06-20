using JQ.Result;
using Monitor.Domain.IDomainServer;
using Monitor.Domain.IRepository;
using Monitor.IUserApplication;
using Monitor.TransDto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JQ.Extensions;
using Monitor.Domain.Model;

namespace Monitor.UserApplication
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/19 11:39:06
    /// </summary>
    public class AdminApplication : IAdminApplication
    {
        private readonly IAdminDomainServer _adminDomainServer;
        private readonly IAdminRepository _adminRepository;
        private readonly ILoginRecordRepository _loginRecordRepository;

        public AdminApplication(IAdminDomainServer adminDomainServer, IAdminRepository adminRepository, ILoginRecordRepository loginRecordRepository)
        {
            _adminDomainServer = adminDomainServer;
            _adminRepository = adminRepository;
            _loginRecordRepository = loginRecordRepository;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>用户信息</returns>
        public OperateResult<AdminDto> Login(string userName, string pwd)
        {
            var adminInfo = _adminRepository.GetInfo(m => m.FIsDeleted == false && m.UserName == userName.Trim());
            _adminDomainServer.LoginCheck(adminInfo, pwd);
            var adminDto = adminInfo.MapperTo<AdminDto>();
            adminInfo.ChangeLastLoginInfo(Domain.ValueObject.SitePort.WebPC);
            _adminRepository.UpdateOne(m => m.AdminId == adminInfo.AdminId, new { LastLoginInfo = adminInfo.LastLoginInfo });
            _loginRecordRepository.InsertOne(new LoginRecordInfo()
            {
                AdminId = adminInfo.AdminId,
                LoginLogInfo = adminInfo.LastLoginInfo
            });
            return OperateUtil.Success(adminDto, "登录成功");
        }
    }
}
