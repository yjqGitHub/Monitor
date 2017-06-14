namespace JQ.MQ.Logger
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MQLoggerConfig.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/12 21:19:17
    /// </summary>
    public sealed class MQLoggerConfig : MQConfig
    {
        public MQLoggerConfig(string hostName, string userName, string password) : base(hostName, userName, password)
        {
        }
    }
}