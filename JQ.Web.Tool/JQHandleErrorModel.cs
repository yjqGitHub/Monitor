using System;

namespace JQ.Web.Tool
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：JQHandleErrorModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：错误处理方法
    /// 创建标识：yjq 2017/6/11 0:39:26
    /// </summary>
    public sealed class JQHandleErrorModel
    {
        public JQHandleErrorModel()
        {
            CreateTime = DateTime.Now;
        }

        public JQHandleErrorModel(string errorMsg, bool isHaveClose = false, bool isHavingBack = true) : this()
        {
            ErrorMsg = errorMsg;
            IsHaveClose = isHaveClose;
            IsHavingBack = isHavingBack;
        }

        public JQHandleErrorModel(Exception ex, bool isHaveClose = false, bool isHavingBack = true) : this(ex.Message, isHaveClose: isHaveClose, isHavingBack: isHavingBack)
        {
        }

        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 返回地址
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// 是否有关闭按钮
        /// </summary>
        public bool IsHaveClose { get; set; }

        /// <summary>
        /// 是否有返回按钮
        /// </summary>
        public bool IsHavingBack { get; set; }
    }
}