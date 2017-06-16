namespace JQ.Domain.Entities
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IEntity.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IEntity
    /// 创建标识：yjq 2017/6/16 20:14:10
    /// </summary>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}