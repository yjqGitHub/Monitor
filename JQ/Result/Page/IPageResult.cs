﻿using System.Collections.Generic;

namespace JQ.Result
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IPageResult.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IPageResult
    /// 创建标识：yjq 2017/6/18 11:20:28
    /// </summary>
    public interface IPageResult<T> : IEnumerable<T> where T : new()
    {
        /// <summary>
        /// 总数量
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// 总页数
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// 当前页面
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// 页长
        /// </summary>
        int PageSize { get; }
    }
}