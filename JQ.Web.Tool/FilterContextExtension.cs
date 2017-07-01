using JQ.Web.Tool.ViewResults;
using System;
using System.Web.Mvc;

namespace JQ.Web.Tool
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：FilterContextExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：扩展类
    /// 创建标识：yjq 2017/6/15 13:19:20
    /// </summary>
    public static class FilterContextExtension
    {
        /// <summary>
        /// 错误页面地址
        /// </summary>
        private const string _VIEW_ERROR = "~/Views/Shared/Error.cshtml";

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

        /// <summary>
        /// 获取参数错误操作方法结果
        /// </summary>
        /// <param name="filterContext"></param>
        /// <param name="msg">反馈内容</param>
        /// <param name="isHaveClose">是否有关闭按钮</param>
        /// <param name="isHavingBack">是否有返回按钮</param>
        /// <param name="errorView">错误页面</param>
        /// <returns>操作方法结果</returns>
        public static ActionResult GetParamErrorActionResult(this ControllerContext filterContext, string msg, bool isHaveClose = false, bool isHavingBack = true, string errorView = null)
        {
            if (filterContext.IsAjaxRequest())
            {
                return JQJsonResult.ParamError(msg);
            }
            return new ViewResult() { ViewName = errorView ?? _VIEW_ERROR, ViewData = new ViewDataDictionary<JQHandleErrorModel>(new JQHandleErrorModel(msg)) };
        }

        /// <summary>
        /// 获取异常操作方法结果
        /// </summary>
        /// <param name="filterContext"></param>
        /// <param name="exception">异常信息</param>
        /// <param name="isHaveClose">是否有关闭按钮</param>
        /// <param name="isHavingBack">是否有返回按钮</param>
        /// <param name="errorView">错误页面</param>
        /// <returns>操作方法结果</returns>
        public static ActionResult GetExceptionActionResult(this ControllerContext filterContext, Exception exception, bool isHaveClose = false, bool isHavingBack = true, string errorView = null)
        {
            if (filterContext.IsAjaxRequest())
            {
                return JQJsonResult.Exception(exception);
            }
            else
            {
                UrlHelper url = new UrlHelper(filterContext.RequestContext);
                return new ViewResult() { ViewName = errorView ?? _VIEW_ERROR, ViewData = new ViewDataDictionary<JQHandleErrorModel>(new JQHandleErrorModel(exception)) };
            }
        }
    }
}