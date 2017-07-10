using JQ.Extensions;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Monitor.Web.Tool.SelectItems
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：PageSizeSelectItem.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：分页长度下拉框选择列表
    /// 创建标识：yjq 2017/7/10 12:45:38
    /// </summary>
    public static partial class SelectItemHelper
    {
        private static int[] PageSizeArray = new int[] { 30, 50, 100, 150 };//分页长度数组

        /// <summary>
        /// 获取分页长度的选择列表
        /// </summary>
        /// <returns>分页长度的选择列表</returns>
        public static IEnumerable<SelectListItem> GetPageSizeListItem()
        {
            List<SelectListItem> selectListItemList = new List<SelectListItem>();
            PageSizeArray.ForEach(pageSize =>
            {
                selectListItemList.Add(new SelectListItem() { Text = pageSize.ToString(), Value = pageSize.ToString() });
            });
            return selectListItemList;
        }
    }
}