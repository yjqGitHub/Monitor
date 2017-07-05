using JQ.Extensions;
using JQ.Result;
using Monitor.Domain.IDomainServer;
using Monitor.Domain.IRepository;
using Monitor.ICache;
using Monitor.IUserApplication;
using Monitor.TransDto.Admin;
using System.Threading.Tasks;

namespace Monitor.UserApplication
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AuthorityApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AuthorityApplication
    /// 创建标识：yjq 2017/7/5 20:45:09
    /// </summary>
    public sealed class AuthorityApplication : IAuthorityApplication
    {
        private readonly IAdminDomainServer _adminDomainServer;
        private readonly IAuthorityCache _authorityCache;
        private readonly IAuthorityDomainServer _authorityDomainServer;
        private readonly IAuthorityRepository _authorityRepository;
        private readonly IWebSiteDomainServer _webSiteDomainServer;

        public AuthorityApplication(IAdminDomainServer adminDomainServer, IAuthorityCache authorityCache, IAuthorityDomainServer authorityDomainServer, IAuthorityRepository authorityRepository, IWebSiteDomainServer webSiteDomainServer)
        {
            _adminDomainServer = adminDomainServer;
            _authorityCache = authorityCache;
            _authorityDomainServer = authorityDomainServer;
            _authorityRepository = authorityRepository;
            _webSiteDomainServer = webSiteDomainServer;
        }

        /// <summary>
        /// 用户授权，成功返回token
        /// </summary>
        /// <param name="appId">授权站点ID</param>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>成功返回token</returns>
        public async Task<OperateResult<string>> AuthorityAsync(string appId, string userName, string pwd)
        {
            await _webSiteDomainServer.CheckExistAsync(appId);
            var adminInfo = await _adminDomainServer.LoginAsync(userName, pwd, Domain.ValueObject.SitePort.WebPC);
            if (adminInfo != null)
            {
                string token = _authorityDomainServer.CreateToken();
                var lastAuthorityInfo = await _authorityRepository.GetLastAuthorityInfoAsync(adminInfo.AdminId);
                var adminDto = adminInfo.MapperTo<AdminDto>();
                //将旧的所有token设置为失效
                await _authorityRepository.UpdateAuthorityInvalidAsync(adminInfo.AdminId);
                //添加当前token
                await _authorityRepository.InsertOneAsync(new Domain.Model.AuthorityInfo(adminInfo.AdminId, token));
                //设置新的token
                await _authorityCache.AddAuthorityTokenAsync(token, adminDto);
                //移除旧的token
                await _authorityCache.RemoveAuthorityTokenAsync(lastAuthorityInfo?.AuthorityToken);
                return OperateUtil.Success(token, "授权成功");
            }
            return OperateUtil.ParamError<string>("授权失败");
        }
    }
}