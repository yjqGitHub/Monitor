using JQ.Extensions;
using JQ.Result;
using JQ.SysConstants;
using System;
using System.Text;
using System.Web.Mvc;

namespace JQ.Web.Tool.ViewResults
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：JQJsonResult.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：JQJsonResult
    /// 创建标识：yjq 2017/6/11 0:18:03
    /// </summary>
    public sealed class JQJsonResult : ActionResult
    {
        public JQJsonResult()
        {
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 编码格式
        /// </summary>
        public Encoding ContentEncoding { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (Data == null)
            {
                new EmptyResult().ExecuteResult(context);
                return;
            }
            context.HttpContext.Response.ContentType = SysConstant.CONTENTTYPE_JSON;
            context.HttpContext.Response.ContentEncoding = ContentEncoding ?? Encoding.UTF8;
            context.HttpContext.Response.Output.Write(Data.ToJson());
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="ex">异常信息</param>
        /// <param name="memberName">调用名字</param>
        /// <returns></returns>
        public static JQJsonResult Exception(Exception ex, string memberName = null)
        {
            return new JQJsonResult { Data = AjaxResultInfo.Exception(ex, memberName: memberName) };
        }

        /// <summary>
        /// 参数错误
        /// </summary>
        /// <param name="msg">错误内容</param>
        /// <returns></returns>
        public static JQJsonResult ParamError(string msg)
        {
            return new JQJsonResult { Data = AjaxResultInfo.ParamError(msg) };
        }

        /// <summary>
        /// 请求失败
        /// </summary>
        /// <param name="msg">失败原因</param>
        /// <returns></returns>
        public static JQJsonResult Failed(string msg)
        {
            return new JQJsonResult { Data = AjaxResultInfo.Failed(msg) };
        }

        /// <summary>
        /// 请求成功
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="data">结果</param>
        /// <returns></returns>
        public static JQJsonResult Success(string msg, object data)
        {
            return new JQJsonResult { Data = AjaxResultInfo.Success(msg, data) };
        }

        public static JQJsonResult Create<T>(IOperateResult<T> operateResult)
        {
            return new JQJsonResult { Data = operateResult.ToAjaxResult() };
        }

        public static JQJsonResult Create(IOperateResult operateResult)
        {
            return new JQJsonResult { Data = operateResult.ToAjaxResult() };
        }
    }
}