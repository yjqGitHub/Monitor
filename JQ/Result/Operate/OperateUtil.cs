using JQ.Extensions;
using System;
using System.Collections.Concurrent;
using System.Reflection.Emit;

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
        public static OperateResult Exception(Exception ex)
        {
            return new OperateResult(ex);
        }

        /// <summary>
        /// 参数错误
        /// </summary>
        /// <param name="msg">信息</param>
        /// <returns>操作结果</returns>
        public static OperateResult ParamError(string msg)
        {
            return new OperateResult(OperateState.ParamError, msg);
        }

        /// <summary>
        /// 创建成功的操作结果
        /// </summary>
        /// <returns>操作结果</returns>
        public static OperateResult Success()
        {
            return new OperateResult(OperateState.Success);
        }

        /// <summary>
        /// 创建成功的操作结果
        /// </summary>
        /// <param name="msg">信息</param>
        /// <returns>操作结果</returns>
        public static OperateResult Success(string msg)
        {
            return new OperateResult(OperateState.Success, msg);
        }

        /// <summary>
        /// 创建成功的操作结果
        /// </summary>
        /// <typeparam name="T">结果类型</typeparam>
        /// <param name="value">值类型</param>
        /// <returns>操作结果</returns>
        public static OperateResult<T> Success<T>(T value)
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
        public static OperateResult<T> Success<T>(T value, string msg)
        {
            return new OperateResult<T>(OperateState.Success, msg)
            {
                Value = value
            };
        }

        /// <summary>
        /// 创建OperateResult的Emit方法缓存
        /// </summary>
        private static ConcurrentDictionary<RuntimeTypeHandle, DynamicMethod> _CreateOperateResultCache = new ConcurrentDictionary<RuntimeTypeHandle, DynamicMethod>();

        public static OperateResult EmitCreate(Type operateType, OperateState operateState, string msg)
        {
            var method = _CreateOperateResultCache.GetValue(operateType.TypeHandle, () =>
             {
                 return EmitMethodCreate(operateType);
             });
            var fuc = (Func<OperateState, string, OperateResult>)method.CreateDelegate(typeof(Func<OperateState, string, OperateResult>));
            return fuc(operateState, msg);
        }

        private static DynamicMethod EmitMethodCreate(Type operateType)
        {
            DynamicMethod createMethod = new DynamicMethod("CreateOperateResult" + operateType.Name, operateType, new Type[] { typeof(OperateState), typeof(string) }, true);
            ILGenerator il = createMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Newobj, operateType.GetConstructor(new Type[] { typeof(OperateState), typeof(string) }));
            il.Emit(OpCodes.Ret);
            return createMethod;
        }
    }
}