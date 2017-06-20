using JQ.MongoDb;
using Monitor.Domain.Model;

namespace Monitor.Domain.IRepository
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ILoginRecordRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ILoginRecordRepository
    /// 创建标识：yjq 2017/6/20 20:34:29
    /// </summary>
    public interface ILoginRecordRepository : IMongoDbBaseRepository<LoginRecordInfo>
    {
    }
}