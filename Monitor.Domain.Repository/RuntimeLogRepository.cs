using JQ.MongoDb;
using Monitor.Domain.IRepository;
using Monitor.Domain.Model;
using Monitor.Infrastructure.Mongo;

namespace Monitor.Domain.Repository
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RuntimeLogRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/27 15:13:57
    /// </summary>
    public sealed class RuntimeLogRepository : MongoBaseRepository<RuntimeLogInfo>, IRuntimeLogRepository
    {
        public RuntimeLogRepository(IMongoDatabaseProvider databaseProvider) : base(databaseProvider, MonogoDbConfigUtil.GetDefaultConfig())
        {
        }
    }
}