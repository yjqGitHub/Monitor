using JQ.MongoDb;
using Monitor.Domain.Model;

namespace Monitor.Domain.IRepository
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IAuthorityRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IAuthorityRepository接口
    /// 创建标识：yjq 2017/7/5 15:40:36
    /// </summary>
    public interface IAuthorityRepository : IMongoDbBaseRepository<AuthorityInfo>
    {
    }
}