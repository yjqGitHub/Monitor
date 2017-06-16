using JQ.Utils;
using MongoDB.Driver;

namespace JQ.MongoDb
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：MonogoDbConfig.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MonogoDbConfig
    /// 创建标识：yjq 2017/6/16 22:27:15
    /// </summary>
    public class MonogoDbConfig
    {
        public MonogoDbConfig()
        {
        }

        public MonogoDbConfig(string connectionString, string databaseName) : this()
        {
            EnsureUtil.NotNullAndNotEmptyWhiteSpace(connectionString, "connectionString");
            EnsureUtil.NotNullAndNotEmptyWhiteSpace(databaseName, "databaseName");
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 库名字
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// 根据包含数据库名字的连接字符串创建MonogoDb配置
        /// </summary>
        /// <param name="connectionString">包含数据库名字的连接字符串</param>
        /// <returns>MonogoDb配置</returns>
        public static MonogoDbConfig CreateConfig(string connectionString)
        {
            MongoUrl mongoUrl = new MongoUrl(connectionString);
            return new MonogoDbConfig(connectionString, mongoUrl.DatabaseName);
        }

        /// <summary>
        /// 根据连接字符串和数据库名字创建MonogoDb配置
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="databaseName">数据库名字</param>
        /// <returns>MonogoDb配置</returns>
        public static MonogoDbConfig CreateConfig(string connectionString, string databaseName)
        {
            return new MonogoDbConfig(connectionString, databaseName);
        }
    }
}