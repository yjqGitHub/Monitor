using JQ.Extensions;
using Newtonsoft.Json;
using System;

namespace JQ.Result
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AjaxResultInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AjaxResultInfo
    /// 创建标识：yjq 2017/6/11 0:30:36
    /// </summary>
    [Serializable]
    public sealed class AjaxResultInfo
    {
        public AjaxResultInfo()
        {
        }

        public AjaxResultInfo(AjaxState state)
            : this()
        {
            State = state;
        }

        public AjaxResultInfo(AjaxState state, string msg)
            : this(state)
        {
            Message = msg;
        }

        public AjaxResultInfo(AjaxState state, string msg, object data)
            : this(state, msg)
        {
            Data = data;
        }

        public AjaxResultInfo(OperateState state) : this(GetAjaxState(state))
        {
        }

        public AjaxResultInfo(OperateState state, string msg) : this(GetAjaxState(state), msg)
        {
        }

        public AjaxResultInfo(OperateState state, string msg, object data) : this(GetAjaxState(state), msg, data)
        {
        }

        /// <summary>
        /// 操作状态
        /// </summary>
        public AjaxState State { get; set; }

        /// <summary>
        /// 附加说明
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [JsonProperty(PropertyName = "Data", NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

        /// <summary>
        /// 跳转地址
        /// </summary>
        [JsonProperty(PropertyName = "RedirectUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string RedirectUrl { get; set; }

        public override string ToString()
        {
            return this.ToJson();
        }

        public static AjaxResultInfo Failed(string msg)
        {
            return new AjaxResultInfo()
            {
                State = AjaxState.Failed,
                Message = msg
            };
        }

        public static AjaxResultInfo Exception(Exception ex, string memberName = null)
        {
            if (ex is JQException)
            {
                return new AjaxResultInfo(AjaxState.Failed, ex.Message);
            }
            return new AjaxResultInfo(AjaxState.Failed, "发生系统错误,请与管理员联系");
        }

        public static AjaxResultInfo ParamError(string msg)
        {
            return new AjaxResultInfo(AjaxState.Failed, msg);
        }

        public static AjaxResultInfo Success(string msg, object data)
        {
            return new AjaxResultInfo(AjaxState.Success, msg, data);
        }

        public static AjaxResultInfo NoLogin(string loginUrl)
        {
            return new AjaxResultInfo(AjaxState.NoLogin, "请先登录") { RedirectUrl = loginUrl };
        }

        private static AjaxState GetAjaxState(OperateState operateState)
        {
            AjaxState state;
            switch (operateState)
            {
                case OperateState.Success:
                    state = AjaxState.Success;
                    break;

                default:
                    state = AjaxState.Failed;
                    break;
            }
            return state;
        }
    }
}