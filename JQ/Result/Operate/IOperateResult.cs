namespace JQ.Result
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IOperateResult.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：操作结果
    /// 创建标识：yjq 2017/6/19 17:17:42
    /// </summary>
    public interface IOperateResult
    {
        /// <summary>
        /// 操作状态
        /// </summary>
        OperateState State { get; set; }

        /// <summary>
        /// 附加说明
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 判断操作是否成功
        /// </summary>
        /// <returns>true表示成功</returns>
        bool IsSuccess
        {
            get;
        }
        /// <summary>
        /// 转为AjaxResultInfo
        /// </summary>
        /// <returns></returns>
        AjaxResultInfo ToAjaxResult();
    }

    public interface IOperateResult<T> : IOperateResult
    {
        /// <summary>
        /// 值
        /// </summary>
        T Value { get; set; }
    }
}