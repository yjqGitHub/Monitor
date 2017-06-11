using System;
using System.Runtime.Serialization;

namespace JQ
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：JQException.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：JQException
    /// 创建标识：yjq 2017/6/10 11:29:11
    /// </summary>
    public sealed class JQException : Exception
    {
        public JQException()
        {
        }

        public JQException(string msg)
            : base(msg)
        {
        }

        public JQException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }

        public JQException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}