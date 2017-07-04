using JQ.MongoDb;
using Monitor.Domain.Model;

namespace Monitor.Domain.IRepository
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IWebSiteRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IWebSiteRepository接口
    /// 创建标识：yjq 2017/7/4 10:18:28
    /// </summary>
    public interface IWebSiteRepository : IMongoDbBaseRepository<WebSiteInfo>
    {
    }
}