namespace JQ.Statistics
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：NoSqlStatistic.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：NoSql统计
    /// 创建标识：yjq 2017/7/6 22:35:51
    /// </summary>
    public class NoSqlStatistic
    {
        /// <summary>
        /// 调用方法
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// 消耗时间
        /// </summary>
        public double Millisecond { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}