using JQ.ParamterValidate;
using Monitor.Domain.IDomainServer;
using Monitor.Domain.IRepository;
using Monitor.ICache;
using System;

namespace Monitor.Domain.DomainServer
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AuthorityDomainServer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AuthorityDomainServer
    /// 创建标识：yjq 2017/7/5 20:55:58
    /// </summary>
    public sealed class AuthorityDomainServer : IAuthorityDomainServer
    {
        private readonly IAuthorityCache _authorityCache;
        private readonly IAuthorityRepository _authorityRepository;

        public AuthorityDomainServer(IAuthorityCache authorityCache, IAuthorityRepository authorityRepository)
        {
            _authorityCache = authorityCache;
            _authorityRepository = authorityRepository;
        }

        /// <summary>
        /// 创建一个令牌
        /// </summary>
        /// <returns>令牌</returns>
        public string CreateToken()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 校验token是否生效
        /// </summary>
        /// <param name="token">要校验的token</param>
        public void CheckTokenAvailable(string token)
        {
            token.NotNullAndNotEmptyWhiteSpace("token已失效");
            if (!_authorityCache.IsExistToken(token))
            {
                _authorityRepository.GetInfo(m => m.AuthorityToken == token && m.State == ValueObject.AuthorityState.Authoritied && m.IsDeleted == false).NotNull("token已失效");
            }
        }
    }
}