using System;

namespace JQ.Result
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：OperateResult.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：操作结果类
    /// 创建标识：yjq 2017/6/11 0:26:07
    /// </summary>
    [Serializable]
    public class OperateResult<T> : IOperateResult<T>
    {
        public OperateResult()
        {
        }

        public OperateResult(OperateState state) : this()
        {
            State = state;
        }

        public OperateResult(OperateState state, string msg)
            : this(state)
        {
            Message = msg;
        }

        public OperateResult(Exception ex) : this()
        {
            if (ex is JQException)
            {
                State = OperateState.ParamError;
                Message = ex.Message;
            }
            else
            {
                State = OperateState.Failed;
                Message = "系统错误,请联系管理员";
            }
        }

        /// <summary>
        /// 操作状态
        /// </summary>
        public OperateState State { get; set; }

        /// <summary>
        /// 附加说明
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 判断操作是否成功
        /// </summary>
        /// <returns>true表示成功</returns>
        public bool IsSuccess
        {
            get { return State == OperateState.Success; }
        }

        public T Value { get; set; }

        public virtual AjaxResultInfo ToAjaxResult()
        {
            return new AjaxResultInfo(State, Message, Value);
        }
    }
}