using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Monitor.Web.Tool.Filters
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AuthorityCheckAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：授权校验
    /// 创建标识：yjq 2017/7/5 10:03:07
    /// </summary>
    public class AuthorityCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUserId = WebTool.GetCurrentUserId();
            if (currentUserId == ObjectId.Empty)
            {
                //未授权
            }
            else
            {
                //已授权
                //返回地址
                string backUrl = filterContext.HttpContext.Request["backUrl"];

            }

            base.OnActionExecuting(filterContext);
        }
    }
}
