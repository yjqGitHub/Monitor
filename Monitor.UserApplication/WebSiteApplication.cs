using JQ.Result;
using Monitor.Domain.IRepository;
using Monitor.IUserApplication;
using Monitor.TransDto.WebSite;
using JQ.ParamterValidate;

namespace Monitor.UserApplication
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：WebSiteApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/4 10:41:46
    /// </summary>
    public class WebSiteApplication : IWebSiteApplication
    {
        private readonly IWebSiteRepository _webSiteRepository;

        public WebSiteApplication(IWebSiteRepository webSiteRepository)
        {
            _webSiteRepository = webSiteRepository;
        }

        /// <summary>
        /// 根据AppId获取站点信息
        /// </summary>
        /// <param name="appId">要获取的AppId</param>
        /// <returns>站点信息</returns>
        public OperateResult<WebSiteDto> GetSite(string appId)
        {
            appId.NotNullAndNotEmptyWhiteSpace("用户信息错误");
            var webSiteInfo = _webSiteRepository.GetDto(m => m.AppId == appId && m.IsDeleted == false && m.State == Domain.ValueObject.SiteState.Normal, m => new WebSiteDto
            {
                AppId = m.AppId,
                AppSecret = m.AppSecret,
                SiteDefaultBackUrl = m.SiteDefaultBackUrl,
                SiteImageUrl = m.SiteImageUrl,
                SiteName = m.SiteName,
                SiteTitle = m.SiteTitle,
                State = m.State,
                WebSiteId = m.WebSiteId
            });
            return OperateUtil.Success(webSiteInfo);
        }
    }
}