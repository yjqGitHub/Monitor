using System;
using System.Web.Mvc;

namespace Monitor.Web.Tool
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：FilterContextExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：扩展类
    /// 创建标识：yjq 2017/7/1 16:27:22
    /// </summary>
    public static class FilterContextExtension
    {
        /// <summary>
        ///  确定指定的 HTTP 请求是否为 AJAX 请求。
        /// </summary>
        /// <param name="filterContext"></param>
        /// <exception cref=”System.ArgumentNullException”>抛出的异常情况</exception>
        /// <returns>如果指定的 HTTP 请求是 AJAX 请求，则为 true；否则为 false。</returns>
        public static bool IsAjaxRequest(this ControllerContext filterContext)
        {
            return filterContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}