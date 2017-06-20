namespace JQ.Redis
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：RedisCacheOption.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：redis配置信息
    /// 创建标识：yjq 2017/6/20 22:12:36
    /// </summary>
    public sealed class RedisCacheOption
    {
        /// <summary>
        /// 连接信息
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 数据库ID
        /// </summary>
        public int DatabaseId { get; set; }

        /// <summary>
        /// 分隔符
        /// </summary>
        public string NamespaceSplitSymbol { get; set; } = ":";

        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }
    }
}