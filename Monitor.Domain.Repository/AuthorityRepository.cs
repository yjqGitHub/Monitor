using JQ.MongoDb;
using MongoDB.Bson;
using Monitor.Domain.IRepository;
using Monitor.Domain.Model;
using Monitor.Infrastructure.Mongo;
using System;
using System.Threading.Tasks;

namespace Monitor.Domain.Repository
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AuthorityRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/5 15:41:20
    /// </summary>
    public sealed class AuthorityRepository : MongoBaseRepository<AuthorityInfo>, IAuthorityRepository
    {
        public AuthorityRepository(IMongoDatabaseProvider databaseProvider) : base(databaseProvider, MonogoDbConfigUtil.GetDefaultConfig())
        {
        }

        #region 根据用户ID将授权信息设置为失效

        /// <summary>
        /// 根据用户ID将授权信息设置为失效
        /// </summary>
        /// <param name="adminId">用户ID</param>
        /// <returns>true表示成功</returns>
        public bool UpdateAuthorityInvalid(ObjectId adminId)
        {
            return UpdateMany(m => m.AdminId == adminId && m.State == ValueObject.AuthorityState.Authoritied && m.IsDeleted == false, new
            {
                State = ValueObject.AuthorityState.Invalid,
                InvalidTime = DateTime.Now,
                LastModifyTime = DateTime.Now
            }) > 0;
        }

        /// <summary>
        /// 异步根据用户ID将授权信息设置为失效
        /// </summary>
        /// <param name="adminId">用户ID</param>
        /// <returns>true表示成功</returns>
        public async Task<bool> UpdateAuthorityInvalidAsync(ObjectId adminId)
        {
            return await UpdateManyAsync(m => m.AdminId == adminId && m.State == ValueObject.AuthorityState.Authoritied && m.IsDeleted == false, new
            {
                State = ValueObject.AuthorityState.Invalid,
                InvalidTime = DateTime.Now,
                LastModifyTime = DateTime.Now
            }) > 0;
        }

        #endregion 根据用户ID将授权信息设置为失效
    }
}