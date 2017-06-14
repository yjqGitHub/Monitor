using JQ.Utils;
using JQ.Web.Tool.ViewResults;
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
            ActionResult actionResult = null;
            if (filterContext.Exception is JQException)
            {
                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    actionResult = JQJsonResult.ParamError(filterContext.Exception.Message);
                }
                else
                {
                    UrlHelper url = new UrlHelper(filterContext.RequestContext);
                    actionResult = new ViewResult() { ViewName = "~/Views/Shared/Error.cshtml", ViewData = new ViewDataDictionary<JQHandleErrorModel>(new JQHandleErrorModel(filterContext.Exception)) };
                }
            }
            else
            {
                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    actionResult = JQJsonResult.Failed("发生系统错误,请与管理员联系");
                }
                else
                {
                    UrlHelper url = new UrlHelper(filterContext.RequestContext);
                    actionResult = new ViewResult() { ViewName = "~/Views/Shared/Error.cshtml", ViewData = new ViewDataDictionary<JQHandleErrorModel>(new JQHandleErrorModel()) };
                }
            }
            filterContext.Result = actionResult;
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}