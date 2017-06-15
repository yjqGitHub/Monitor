﻿using JQ.Configurations;

namespace Monitor.WebManage.App_Start
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：BootStrapper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：BootStrapper
    /// 创建标识：yjq 2017/6/15 14:42:40
    /// </summary>
    public sealed class BootStrapper
    {
        /// <summary>
        /// 启动
        /// </summary>
        public static void Install()
        {
            JQConfiguration.Install("Monitor", "Monitor", "Monitor.ValidateCode", "Monitor.ValidateCode").UseDefaultConfig();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public static void UnInstall()
        {
            JQConfiguration.UnInstall();
        }
    }
}