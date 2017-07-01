using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using JQ.Extensions;
using JQ.Web.Tool.ViewResults;
using JQ.Utils;
using Monitor.Web.Tool.WebConstant;

namespace Monitor.Web.Tool.Filters
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：LoginAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/1 15:30:15
    /// </summary>
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 用MVC系统自带的功能 获取当前方法上的特性名称
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(NoNeedLoginAttribute), inherit: true)
                                     || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(NoNeedLoginAttribute), inherit: true);
            if (skipAuthorization)
            {
                return;
            }

            //ajax请求和直接请求需要区分
            //ajax请求时，如果本地没有Ticket，则反馈客户端未授权。有Ticket则请求授权校验地址
            //直接请求时，如果没有Ticket则跳转到授权地址，并设置返回地址。有Ticket则请求授权校验地址

            string ticket = filterContext.HttpContext.Request["ticket"];

            if (filterContext.IsAjaxRequest())
            {
                if (ticket.IsNullOrWhiteSpace())
                {
                    filterContext.Result = JQJsonResult.NoLogin(ConfigUtil.GetValue(ConfigKeyConstant.CONFIG_KEY_AUTHORITY_URL, memberName: "LoginAttribute-OnActionExecuting-IsAjaxRequest"));
                }
                else
                {

                }
            }

            filterContext.Result = new RedirectResult("~/Account/Login", true);

            // 检查是否登录  需判断ajax请求还是直接请求
            // if (!UserCookie.CheckLoginToAdmin())
            // {
            // filterContext.Result = new RedirectResult("~/Admin/Account/Login", true);
            // }

            base.OnActionExecuting(filterContext);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class NoNeedLoginAttribute : Attribute
    {
    }
}
