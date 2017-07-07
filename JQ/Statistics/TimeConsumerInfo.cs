namespace JQ.Statistics
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：TimeConsumerInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/7 14:26:04
    /// </summary>
    public class TimeConsumerInfo
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
        /// 消耗类型
        /// </summary>
        public TimeConsumerType ComsumerType { get; set; }

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