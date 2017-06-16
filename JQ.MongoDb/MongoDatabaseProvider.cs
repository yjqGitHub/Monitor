using JQ.Utils;
using MongoDB.Driver;

namespace JQ.MongoDb
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：MongoDatabaseProvider.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MongoDatabaseProvider
    /// 创建标识：yjq 2017/6/16 22:25:15
    /// </summary>
    public sealed class MongoDatabaseProvider : IMongoDatabaseProvider
    {
        /// <summary>
        ///  获取 <see cref="IMongoDatabase"/>.
        /// </summary>
        /// <param name="config">MongoDb配置</param>
        /// <exception cref="System.ArgumentNullException">config</exception>
        /// <returns><see cref="IMongoDatabase"/></returns>
        public IMongoDatabase GetDatabase(MonogoDbConfig config)
        {
            EnsureUtil.NotNull(config, "MonogoDbConfig");
            MongoUrl mongoUrl = new MongoUrl(config.ConnectionString);
            var mongoClient = new MongoClient(mongoUrl);
            return mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }
    }
}