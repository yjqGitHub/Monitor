using JQ.Result;
using Monitor.TransDto.WebSite;

namespace Monitor.IUserApplication
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IWebSiteApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IWebSiteApplication接口
    /// 创建标识：yjq 2017/7/4 10:40:02
    /// </summary>
    public interface IWebSiteApplication
    {
        /// <summary>
        /// 根据AppId获取站点信息
        /// </summary>
        /// <param name="appId">要获取的AppId</param>
        /// <returns>站点信息</returns>
        OperateResult<WebSiteDto> GetSite(string appId);

        /// <summary>
        /// 获取站点列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>站点列表</returns>
        OperateResult<IPageResult<WebSiteQueryDto>> LoadWebSiteList(WebSiteQueryWhereDto queryWhere);
    }
}