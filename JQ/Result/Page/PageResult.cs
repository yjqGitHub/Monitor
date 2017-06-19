﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace JQ.Result
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：PageResult.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：PageResult
    /// 创建标识：yjq 2017/6/18 11:18:49
    /// </summary>
    public class PageResult<T> : IPageResult<T> where T : new()
    {
        private int _totalCount;
        private int _pageIndex;
        private int _pageSize;
        private int _pageCount;
        private IEnumerable<T> _data;

        /// <summary>
        ///
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页长</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="data">分页内容</param>
        /// <param name="maxPageCount">最大页码（默认为空，不生效）</param>
        public PageResult(int pageIndex, int pageSize, int totalCount, IEnumerable<T> data, int? maxPageCount = null)
        {
            _pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            _pageSize = pageSize < 0 ? 1 : pageSize;
            _totalCount = totalCount;
            _pageCount = (_totalCount + _pageSize - 1) / _pageSize;
            if (maxPageCount != null && _pageCount > maxPageCount.Value && maxPageCount.Value >= 1)
            {
                _pageCount = maxPageCount.Value;
            }
            _data = data;
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get
            {
                return _totalCount;
            }
        }

        /// <summary>
        /// 页面总数
        /// </summary>
        public int PageCount
        {
            get
            {
                return _pageCount;
            }
        }

        /// <summary>
        /// 分页内容
        /// </summary>
        public IEnumerable<T> Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }
        }

        /// <summary>
        /// 页长
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}