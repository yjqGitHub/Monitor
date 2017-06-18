using JQ.MongoDb;

namespace Monitor.Domain.Repository.Constants
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：MonogoDbConfigConstant.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MonogoDbConfigConstant
    /// 创建标识：yjq 2017/6/18 18:13:15
    /// </summary>
    public partial class RepositoryConstant
    {
        public static readonly MonogoDbConfig MonitorMongoDbConfig = MonogoDbConfig.CreateConfig("mongodb://yjq:123456@localhost:27017/Monitor");
    }
}