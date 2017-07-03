﻿using JQ.Extensions;
using JQ.Result;
using JQ.Utils;
using JQ.Web;
using JQ.Web.Tool.ViewResults;
using Monitor.Web.Tool.Authority;
using Monitor.Web.Tool.WebConstant;
using System;
using System.Linq;
using System.Web.Mvc;

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
                if (ticket.IsNullOrWhiteSpace() || !CheckTicket(ticket))
                {
                    filterContext.Result = JQJsonResult.NoLogin(ConfigUtil.GetValue(ConfigKeyConstant.CONFIG_KEY_AUTHORITY_URL));
                }
            }
            else
            {
                if (ticket.IsNullOrWhiteSpace() || !CheckTicket(ticket))
                {
                    EnhancedUriBuilder uriBuilder = new EnhancedUriBuilder(ConfigUtil.GetValue(ConfigKeyConstant.CONFIG_KEY_AUTHORITY_URL));
                    uriBuilder.QueryItems["backUrl"] = filterContext.HttpContext.Request.Url.ToString();
                    uriBuilder.QueryItems["appId"] = ConfigUtil.GetValue(ConfigKeyConstant.CONFIG_KEY_AUTHORITY_APPID);
                    filterContext.Result = new RedirectResult(uriBuilder.ToString(), true);
                }
            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 检验门票
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        private bool CheckTicket(string ticket)
        {
            //校验ticke是否可用
            AuthorityCheckModel checkModel = new AuthorityCheckModel()
            {
                AppId = ConfigUtil.GetValue(ConfigKeyConstant.CONFIG_KEY_AUTHORITY_APPID),
                Ticket = ticket,
                Version = ConfigUtil.GetValue(ConfigKeyConstant.CONFIG_KEY_AUTHORITY_VERSION),
                TimeTicket = DateTimeUtil.GetTimeSpanNow()
            };
            checkModel.SetSign(ConfigUtil.GetValue(ConfigKeyConstant.CONFIG_KEY_AUTHORITY_APPSECRET));
            HttpClient httpClient = new HttpClient(ConfigUtil.GetValue(ConfigKeyConstant.CONFIG_KEY_AUTHORITY_CHECK_URL));
            var ajaxResult = httpClient.Post<AjaxResultInfo>(checkModel.ToDictionary());
            if (ajaxResult.State == AjaxState.Success)
            {
                return true;
            }
            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class NoNeedLoginAttribute : Attribute
    {
    }
}