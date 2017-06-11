namespace JQ.MQ
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IMQFactory.cs
    /// 类属性：接口
    /// 类功能描述：IMQFactory
    /// 创建标识：yjq 2017/6/11 19:29:56
    /// </summary>
    public interface IMQFactory
    {
        /// <summary>
        /// 创建MQ客户端
        /// </summary>
        /// <param name="mqConfig">MQ配置信息</param>
        /// <returns>MQ客户端</returns>
        IMQClient Create(MQConfig mqConfig);
    }
}