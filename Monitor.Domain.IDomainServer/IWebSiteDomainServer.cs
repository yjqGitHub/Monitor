using System.Threading.Tasks;

namespace Monitor.Domain.IDomainServer
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IWebSiteDomainServer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IWebSiteDomainServer
    /// 创建标识：yjq 2017/7/5 22:57:12
    /// </summary>
    public interface IWebSiteDomainServer
    {
        /// <summary>
        /// 检验站点存在
        /// </summary>
        /// <param name="appId">要校验的站点AppId</param>
        /// <returns></returns>
        Task CheckExistAsync(string appId);
    }
}