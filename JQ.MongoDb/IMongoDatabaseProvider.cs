using MongoDB.Driver;

namespace JQ.MongoDb
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IMongoDatabaseProvider.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IMongoDatabaseProvider
    /// 创建标识：yjq 2017/6/16 22:21:20
    /// </summary>
    public interface IMongoDatabaseProvider
    {
        /// <summary>
        ///  获取 <see cref="IMongoDatabase"/>.
        /// </summary>
        /// <param name="config">MongoDb配置</param>
        /// <exception cref="System.ArgumentNullException">config</exception>
        /// <returns><see cref="IMongoDatabase"/></returns>
        IMongoDatabase GetDatabase(MonogoDbConfig config);
    }
}