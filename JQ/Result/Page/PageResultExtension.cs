using System.Collections.Generic;
using System.Linq;

namespace JQ.Result
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：PageResultExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：PageResultExtension
    /// 创建标识：yjq 2017/7/9 20:32:41
    /// </summary>
    public static class PageResultExtension
    {
        /// <summary>
        /// IPageResult<T>
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="data">待分页的数据</param>
        /// <param name="pageIndex">当前页面</param>
        /// <param name="pageSize">页长</param>
        /// <param name="maxPage">最大页数</param>
        /// <returns>分页结果</returns>
        public static IPageResult<T> PageResult<T>(this IEnumerable<T> data, int pageIndex, int pageSize, int? maxPage = null) where T : new()
        {
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            pageSize = pageSize < 0 ? 1 : pageSize;
            int totalCount = data == null ? 0 : data.Count();
            return new PageResult<T>(pageIndex, pageSize, totalCount, data?.Skip(pageIndex * pageSize).Take(pageSize), maxPageCount: maxPage);
        }
    }
}