using JQ.MongoDb;
using Monitor.Domain.Model;

namespace Monitor.Domain.IRepository
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IRuntimeLogRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IRuntimeLogRepository接口
    /// 创建标识：yjq 2017/6/27 15:13:05
    /// </summary>
    public interface IRuntimeLogRepository : IMongoDbBaseRepository<RuntimeLogInfo>
    {
    }
}