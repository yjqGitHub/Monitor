namespace JQ.Statistics
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：SqlStatistic.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Sql统计
    /// 创建标识：yjq 2017/7/6 22:36:58
    /// </summary>
    public class SqlStatistic
    {
        /// <summary>
        /// Sql文本
        /// </summary>
        public string CommandText { get; set; }

        /// <summary>
        /// 参数解析后Sql文本
        /// </summary>
        public string NoParamCommandText { get; set; }

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