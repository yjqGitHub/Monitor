using JQ.Web.Tool.ViewResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace JQ.Web.Tool.Filters
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ValidateAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Model验证
    /// 创建标识：yjq 2017/6/15 11:41:03
    /// </summary>
    public class ValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 用MVC系统自带的功能 获取当前方法上的特性名称
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(NoNeedValidateAttribute), inherit: true)
                                     || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(NoNeedValidateAttribute), inherit: true);
            if (skipAuthorization)
            {
                return;
            }
            var modelState = ((Controller)(filterContext.Controller)).ModelState;
            if (modelState.IsValid)
            {
                return;
            }
            else
            {
                StringBuilder sbBuilder = new StringBuilder();

                //获取每一个key对应的ModelStateDictionary
                foreach (var value in modelState.Values)
                {
                    //将错误描述添加到sb中
                    foreach (var error in value.Errors)
                    {
                        sbBuilder.Append(error.ErrorMessage).Append(",");
                    }
                }
                sbBuilder.Remove(sbBuilder.Length - 1, 1);
                filterContext.Result = filterContext.GetParamErrorActionResult(sbBuilder.ToString());
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class NoNeedValidateAttribute : Attribute
    {
    }
}