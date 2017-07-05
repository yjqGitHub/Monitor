using Monitor.Domain.IDomainServer;
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
        /// <summary>
        /// 创建一个令牌
        /// </summary>
        /// <returns>令牌</returns>
        public string CreateToken()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}