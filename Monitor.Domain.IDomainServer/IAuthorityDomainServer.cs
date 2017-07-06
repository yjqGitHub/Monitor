namespace Monitor.Domain.IDomainServer
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IAuthorityDomainServer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：授权服务
    /// 创建标识：yjq 2017/7/5 20:55:31
    /// </summary>
    public interface IAuthorityDomainServer
    {
        /// <summary>
        /// 创建一个令牌
        /// </summary>
        /// <returns>令牌</returns>
        string CreateToken();

        /// <summary>
        /// 校验token是否生效
        /// </summary>
        /// <param name="token">要校验的token</param>
        void CheckTokenAvailable(string token);
    }
}