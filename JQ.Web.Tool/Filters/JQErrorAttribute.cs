using JQ.Utils;
using System.Web.Mvc;

namespace JQ.Web.Tool.Filters
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：JQErrorAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：JQErrorAttribute
    /// 创建标识：yjq 2017/6/11 0:43:15
    /// </summary>
    public sealed class JQErrorAttribute : HandleErrorAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var requestUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
            LogUtil.Error(filterContext.Exception, memberName: requestUrl);

            filterContext.Result = filterContext.GetExceptionActionResult(filterContext.Exception);
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}