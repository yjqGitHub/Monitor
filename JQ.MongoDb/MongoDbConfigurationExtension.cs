using JQ.Configurations;

namespace JQ.MongoDb
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：MongoDbConfigurationExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MongoDbConfigurationExtension
    /// 创建标识：yjq 2017/6/18 13:25:35
    /// </summary>
    public static class MongoDbConfigurationExtension
    {
        public static JQConfiguration UseMongoDb(this JQConfiguration configuration)
        {
            configuration.SetDefault<IMongoDatabaseProvider, MongoDatabaseProvider>();
            return configuration;
        }
    }
}