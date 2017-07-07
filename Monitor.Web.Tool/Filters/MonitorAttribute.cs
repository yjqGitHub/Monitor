using JQ.Extensions;
using JQ.Statistics;
using JQ.Utils;
using JQ.Web;
using System;
using System.Web.Mvc;

namespace Monitor.Web.Tool.Filters
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BrowseAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/7 14:08:51
    /// </summary>
    public class MonitorAttribute : ActionFilterAttribute
    {
        private DateTime _stratTime;
        private string _memberName;

        public RequestStatistic RequestStatisticInfo { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stratTime = DateTime.Now;
            _memberName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "-" + filterContext.ActionDescriptor.ActionName;
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            RequestStatisticInfo.MemberName = _memberName;
            RequestStatisticInfo.RequestUrl = WebUtil.GetAbsoluteUrl();
            RequestStatisticInfo.Millisecond = (DateTime.Now - _stratTime).TotalMilliseconds;
            LogUtil.Info(RequestStatisticInfo.ToJson());
            base.OnResultExecuted(filterContext);
        }
    }
}