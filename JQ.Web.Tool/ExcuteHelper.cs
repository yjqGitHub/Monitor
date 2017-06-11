using JQ.Web.Tool.ViewResults;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JQ.Web.Tool
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ExcuteHelper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ExcuteHelper
    /// 创建标识：yjq 2017/6/11 0:36:30
    /// </summary>
    public static class ExcuteHelper
    {
        /// <summary>
        /// 执行返回jaosn结果
        /// </summary>
        /// <param name="modelState">模型绑定状态</param>
        /// <param name="action">执行方法</param>
        /// <param name="memberName">调用的方法名字</param>
        /// <returns>SelfJsonResult</returns>
        public static JQJsonResult ExcuteJsonResult(System.Web.Mvc.ModelStateDictionary modelState, Func<JQJsonResult> action, string memberName = null)
        {
            JQJsonResult result = null;
            try
            {
                if (modelState.IsValid)
                {
                    result = action();
                }
                else
                {
                    result = JQJsonResult.ParamError(modelState.Values.First().Errors[0].ErrorMessage);
                }
            }
            catch (JQException ex)
            {
                // LogUtil.Warn(ex, memberName: memberName);
                result = JQJsonResult.ParamError(ex.Message);
            }
            catch (Exception ex)
            {
                //LogUtil.Error(ex, memberName: memberName);
                result = JQJsonResult.Failed("发生系统错误,请与管理员联系");
            }
            return result;
        }

        /// <summary>
        /// 执行返回json结果
        /// </summary>
        /// <param name="action">执行方法</param>
        /// <param name="memberName">调用的方法名字</param>
        /// <returns>SelfJsonResult</returns>
        public static JQJsonResult ExcuteJsonResult(Func<JQJsonResult> action, string memberName = null)
        {
            JQJsonResult result = null;
            try
            {
                result = action();
            }
            catch (JQException ex)
            {
                //LogUtil.Warn(ex, memberName: memberName);
                result = JQJsonResult.ParamError(ex.Message);
            }
            catch (Exception ex)
            {
                //LogUtil.Error(ex, memberName: memberName);
                result = JQJsonResult.Failed("发生系统错误,请与管理员联系");
            }
            return result;
        }

        /// <summary>
        /// 执行一个返回结果的方法
        /// </summary>
        /// <param name="action">执行方法</param>
        /// <param name="memberName">调用成员名字</param>
        /// <returns>返回结果的方法</returns>
        public static ActionResult ExcuteActionResult(Func<ActionResult> action, string memberName = null)
        {
            ActionResult result = null;
            try
            {
                result = action();
            }
            catch (JQException ex)
            {
                // LogUtil.Warn(ex, memberName: memberName);
                result = CreateErrorViewResult(ex);
            }
            catch (Exception ex)
            {
                //LogUtil.Error(ex, memberName: memberName);
                result = CreateErrorViewResult("发生系统错误, 请与管理员联系");
            }
            return result;
        }

        /// <summary>
        /// 创建错误视图页面结果
        /// </summary>
        /// <param name="ex">错误异常信息</param>
        /// <returns>错误视图页面结果</returns>
        public static ViewResult CreateErrorViewResult(Exception ex)
        {
            return new ViewResult() { ViewName = "/Views/Shared/Error.cshtml", ViewData = new ViewDataDictionary<JQHandleErrorModel>(new JQHandleErrorModel(ex)) };
        }

        /// <summary>
        /// 创建错误视图页面结果
        /// </summary>
        /// <param name="errorMsg">错误信息</param>
        /// <returns>错误视图页面结果</returns>
        public static ViewResult CreateErrorViewResult(string errorMsg)
        {
            return new ViewResult() { ViewName = "/Views/Shared/Error.cshtml", ViewData = new ViewDataDictionary<JQHandleErrorModel>(new JQHandleErrorModel(errorMsg)) };
        }
    }
}