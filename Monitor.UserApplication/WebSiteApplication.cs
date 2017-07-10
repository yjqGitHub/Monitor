using JQ.Result;
using Monitor.Domain.IRepository;
using Monitor.IUserApplication;
using Monitor.TransDto.WebSite;
using JQ.ParamterValidate;
using Monitor.ICache;
using JQ.Extensions;
using System.Linq.Expressions;
using System;
using Monitor.Domain.Model;
using JQ.Utils;

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
        private readonly IWebSiteCache _webSiteCache;

        public WebSiteApplication(IWebSiteRepository webSiteRepository, IWebSiteCache webSiteCache)
        {
            _webSiteRepository = webSiteRepository;
            _webSiteCache = webSiteCache;
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

        /// <summary>
        /// 获取站点列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>站点列表</returns>
        public OperateResult<IPageResult<WebSiteQueryDto>> LoadWebSiteList(WebSiteQueryWhereDto queryWhere)
        {
            queryWhere.NotNull("查询条件不能为空");
            Expression<Func<WebSiteQueryDto, bool>> expression = m => 1 == 1;
            if (queryWhere.AppId.IsNotNullAndNotWhiteSpace())
            {
                expression = expression.And(m => m.AppId == queryWhere.AppId);
            }
            if (queryWhere.SiteName.IsNotNullAndNotWhiteSpace())
            {
                expression = expression.And(m => m.SiteName.Contains(queryWhere.SiteName));
            }
            if (queryWhere.State.IsNotNull())
            {
                expression = expression.And(m => m.State == queryWhere.State);
            };
            var list = _webSiteCache.LoadWebSiteList(expression.Compile(), (m) => m.CreateTime, queryWhere.PageIndex, queryWhere.PageSize, false);
            return OperateUtil.Success(list);
        }
    }
}