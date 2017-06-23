using JQ.MongoDb;
using Monitor.Domain.IRepository;
using Monitor.Domain.Model;
using Monitor.Domain.Repository.Constants;
using Monitor.Infrastructure.Mongo;

namespace Monitor.Domain.Repository
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AdminRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AdminRepository
    /// 创建标识：yjq 2017/6/18 18:11:41
    /// </summary>
    public sealed class AdminRepository : MongoBaseRepository<AdminInfo>, IAdminRepository
    {
        public AdminRepository(IMongoDatabaseProvider databaseProvider) : base(databaseProvider, MonogoDbConfigUtil.GetDefaultConfig())
        {
        }
    }
}