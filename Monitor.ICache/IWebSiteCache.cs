using JQ.Result;
using Monitor.TransDto.WebSite;
using System;

namespace Monitor.ICache
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IWebSiteCache.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IWebSiteCache
    /// 创建标识：yjq 2017/7/9 19:31:09
    /// </summary>
    public interface IWebSiteCache
    {
        /// <summary>
        /// 获取站点列表
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="sort">排序</param>
        /// <param name="pageIndex">当前页面</param>
        /// <param name="pageSize">每页长度</param>
        /// <param name="isDesc">是否倒叙排列</param>
        /// <returns>站点列表</returns>
        IPageResult<WebSiteQueryDto> LoadWebSiteList<TField>(Func<WebSiteQueryDto, bool> filter, Func<WebSiteQueryDto, TField> sort, int pageIndex, int pageSize, bool isDesc);
    }
}