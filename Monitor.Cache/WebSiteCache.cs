using JQ.Redis;
using JQ.Result;
using Monitor.Domain.IRepository;
using Monitor.ICache;
using Monitor.Infrastructure.Redis;
using Monitor.TransDto.WebSite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Cache
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：WebSiteCache.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：WebSiteCache
    /// 创建标识：yjq 2017/7/9 19:29:55
    /// </summary>
    public class WebSiteCache : RedisBaseRepository, IWebSiteCache
    {
        private readonly IWebSiteRepository _webSiteRepository;

        public WebSiteCache(IRedisDatabaseProvider databaseProvider, IWebSiteRepository webSiteRepository) : base(databaseProvider, RedisHelper.GetDefaultOption())
        {
            _webSiteRepository = webSiteRepository;
        }

        private const string _REDIS_KEY_WEBSITELIST = "WebSiteList";

        /// <summary>
        /// 获取站点列表
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="sort">排序</param>
        /// <param name="pageIndex">当前页面</param>
        /// <param name="pageSize">每页长度</param>
        /// <param name="isDesc">是否倒叙排列</param>
        /// <returns>站点列表</returns>
        public IPageResult<WebSiteQueryDto> LoadWebSiteList<TField>(Func<WebSiteQueryDto, bool> filter, Func<WebSiteQueryDto, TField> sort, int pageIndex, int pageSize, bool isDesc)
        {
            var list = GetWebSiteList().Where(filter);
            if (isDesc)
            {
                list = list.OrderByDescending(sort);
            }
            else
            {
                list = list.OrderBy(sort);
            }
            return list.PageResult(pageIndex, pageSize);
        }

        /// <summary>
        /// 获取全部站点列表
        /// </summary>
        /// <returns>全部站点列表</returns>
        private IEnumerable<WebSiteQueryDto> GetWebSiteList()
        {
            return GetValueWhenNotExitThenSet(_REDIS_KEY_WEBSITELIST, key =>
            {
                return RedisClient.StringGet<IEnumerable<WebSiteQueryDto>>(key);
            }, (key, value) =>
             {
                 RedisClient.StringSet(_REDIS_KEY_WEBSITELIST, value);
             }, () =>
              {
                  return _webSiteRepository.GetDtoList(m => new WebSiteQueryDto
                  {
                      AppId = m.AppId,
                      AppSecret = m.AppSecret,
                      CreateTime = m.CreateTime,
                      LastModifyTime = m.LastModifyTime,
                      SiteHost = m.SiteHost,
                      SiteName = m.SiteName,
                      SiteTitle = m.SiteTitle,
                      State = m.State,
                      WebSiteId = m.WebSiteId.ToString()
                  });
              }, memberName: "WebSiteCache-LoadWebSiteList");
        }
    }
}