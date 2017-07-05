using JQ.MongoDb;
using MongoDB.Bson;
using Monitor.Domain.Model;
using System.Threading.Tasks;

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
        /// <summary>
        /// 获取上次授权信息
        /// </summary>
        /// <param name="adminId">用户ID</param>
        /// <returns>上次授权信息</returns>
        Task<AuthorityInfo> GetLastAuthorityInfoAsync(ObjectId adminId);

        /// <summary>
        /// 根据用户ID将授权信息设置为失效
        /// </summary>
        /// <param name="adminId">用户ID</param>
        /// <returns>true表示成功</returns>
        bool UpdateAuthorityInvalid(ObjectId adminId);

        /// <summary>
        /// 异步根据用户ID将授权信息设置为失效
        /// </summary>
        /// <param name="adminId">用户ID</param>
        /// <returns>true表示成功</returns>
        Task<bool> UpdateAuthorityInvalidAsync(ObjectId adminId);
    }
}