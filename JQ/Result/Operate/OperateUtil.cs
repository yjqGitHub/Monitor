using System;

namespace JQ.Result
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：OperateUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/19 17:35:15
    /// </summary>
    public static class OperateUtil
    {
        public static IOperateResult Exception(Exception ex)
        {
            return new OperateResult<object>(ex);
        }

        /// <summary>
        /// 参数错误
        /// </summary>
        /// <param name="msg">信息</param>
        /// <returns>操作结果</returns>
        public static IOperateResult ParamError(string msg)
        {
            return new OperateResult<object>(OperateState.ParamError, msg);
        }

        /// <summary>
        /// 创建成功的操作结果
        /// </summary>
        /// <returns>操作结果</returns>
        public static IOperateResult Success()
        {
            return new OperateResult<object>(OperateState.Success);
        }

        /// <summary>
        /// 创建成功的操作结果
        /// </summary>
        /// <param name="msg">信息</param>
        /// <returns>操作结果</returns>
        public static IOperateResult Success(string msg)
        {
            return new OperateResult<object>(OperateState.Success, msg);
        }

        /// <summary>
        /// 创建成功的操作结果
        /// </summary>
        /// <typeparam name="T">结果类型</typeparam>
        /// <param name="value">值类型</param>
        /// <returns>操作结果</returns>
        public static IOperateResult<T> Success<T>(T value)
        {
            return Success(value, null);
        }

        /// <summary>
        /// 创建成功的操作结果
        /// </summary>
        /// <typeparam name="T">结果类型</typeparam>
        /// <param name="value">值类型</param>
        /// <param name="msg">信息</param>
        /// <returns>操作结果</returns>
        public static IOperateResult<T> Success<T>(T value, string msg)
        {
            return new OperateResult<T>(OperateState.Success, msg)
            {
                Value = value
            };
        }
    }
}