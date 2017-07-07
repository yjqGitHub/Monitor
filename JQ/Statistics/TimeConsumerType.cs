using System.ComponentModel;

namespace JQ.Statistics
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：TimeConsumerType.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：时间消耗类型
    /// 创建标识：yjq 2017/7/7 14:26:49
    /// </summary>
    public enum TimeConsumerType
    {
        /// <summary>
        /// NoSql
        /// </summary>
        [Description("NoSql")]
        NoSql = 1,

        /// <summary>
        /// Cache
        /// </summary>
        [Description("Cache")]
        Cache = 5,

        /// <summary>
        /// Sql
        /// </summary>
        [Description("Sql")]
        Sql = 10
    }
}