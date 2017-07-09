using System;
using System.Linq.Expressions;

namespace JQ.Utils
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ExpressionUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ExpressionUtil
    /// 创建标识：yjq 2017/7/9 22:49:58
    /// </summary>
    public static class ExpressionUtil
    {
        public static Expression<Func<T, object>> GetPropertyExpression<T>(string propertyName)
        {
            var type = typeof(T);
            var parameter = Expression.Parameter(type, "m");
            var member = Expression.Property(parameter, propertyName);
            return Expression.Lambda<Func<T, object>>(member, parameter);
        }

        public static Expression<Func<T, bool>> GetExpression<T>(string propertyName, string value, Func<Expression, Expression, Expression> merge)
        {
            var type = typeof(T);
            var parameter = Expression.Parameter(type, "m");
            var member = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(value);
            var binaryExpression = merge(member, constant);
            return Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);
        }
    }
}