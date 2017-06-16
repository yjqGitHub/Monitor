using JQ.Domain.Entities;

namespace JQ.Domain.Reopsitories
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IRepository
    /// 创建标识：yjq 2017/6/16 20:29:36
    /// </summary>
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
    }
}