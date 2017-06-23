using JQ.MongoDb;
using Monitor.Domain.IRepository;
using Monitor.Domain.Model;
using Monitor.Infrastructure.Mongo;

namespace Monitor.Domain.Repository
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：LoginRecordRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：LoginRecordRepository
    /// 创建标识：yjq 2017/6/20 20:33:51
    /// </summary>
    public sealed class LoginRecordRepository : MongoBaseRepository<LoginRecordInfo>, ILoginRecordRepository
    {
        public LoginRecordRepository(IMongoDatabaseProvider databaseProvider) : base(databaseProvider, MonogoDbConfigUtil.GetDefaultConfig())
        {
        }
    }
}