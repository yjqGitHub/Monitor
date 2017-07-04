using JQ.MongoDb;
using Monitor.Domain.IRepository;
using Monitor.Domain.Model;
using Monitor.Infrastructure.Mongo;

namespace Monitor.Domain.Repository
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：WebSiteRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/4 10:25:28
    /// </summary>
    public sealed class WebSiteRepository : MongoBaseRepository<WebSiteInfo>, IWebSiteRepository
    {
        public WebSiteRepository(IMongoDatabaseProvider databaseProvider) : base(databaseProvider, MonogoDbConfigUtil.GetDefaultConfig())
        {
        }
    }
}