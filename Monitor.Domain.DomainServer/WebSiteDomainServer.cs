using JQ.ParamterValidate;
using Monitor.Domain.IDomainServer;
using Monitor.Domain.IRepository;
using System.Threading.Tasks;

namespace Monitor.Domain.DomainServer
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：WebSiteDomainServer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：WebSiteDomainServer
    /// 创建标识：yjq 2017/7/5 22:57:27
    /// </summary>
    public sealed class WebSiteDomainServer : IWebSiteDomainServer
    {
        private readonly IWebSiteRepository _webSiteRepository;

        public WebSiteDomainServer(IWebSiteRepository webSiteRepository)
        {
            _webSiteRepository = webSiteRepository;
        }

        /// <summary>
        /// 检验站点存在
        /// </summary>
        /// <param name="appId">要校验的站点AppId</param>
        /// <returns></returns>
        public async Task CheckExistAsync(string appId)
        {
            var siteInfo = await _webSiteRepository.GetInfoAsync(m => m.AppId == appId && m.IsDeleted == false && m.State == Domain.ValueObject.SiteState.Normal);
            siteInfo.NotNull("站点信息不存在");
        }
    }
}