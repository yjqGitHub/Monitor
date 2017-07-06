namespace JQ.Statistics
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：CacheStatistic.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：缓存统计
    /// 创建标识：yjq 2017/7/6 22:33:19
    /// </summary>
    public class CacheStatistic
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