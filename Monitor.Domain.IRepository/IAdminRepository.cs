using JQ.MongoDb;
using Monitor.Domain.Model;

namespace Monitor.Domain.IRepository
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IAdminRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IAdminRepository
    /// 创建标识：yjq 2017/6/18 18:10:32
    /// </summary>
    public interface IAdminRepository : IMongoDbBaseRepository<AdminInfo>
    {
    }
}