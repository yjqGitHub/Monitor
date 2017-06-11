using System;
using System.Web.Mvc;

namespace JQ.Web.Tool.Filters
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：CheckLoginAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：检验是否登录过滤器
    /// 创建标识：yjq 2017/6/11 0:13:04
    /// </summary>
    public sealed class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 用MVC系统自带的功能 获取当前方法上的特性名称
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(NoNeedCheckLoginAttribute), inherit: true)
                                     || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(NoNeedCheckLoginAttribute), inherit: true);
            if (skipAuthorization)
            {
                return;
            }

            // 检查是否登录  需判断ajax请求还是直接请求
            // if (!UserCookie.CheckLoginToAdmin())
            // {
            // filterContext.Result = new RedirectResult("~/Admin/Account/Login", true);
            // }

            base.OnActionExecuting(filterContext);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class NoNeedCheckLoginAttribute : Attribute
    {
    }
}