﻿using JQ.Result;
using JQ.Utils;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JQ.MongoDb
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：MongoBaseRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MongoBaseRepository
    /// 创建标识：yjq 2017/6/16 22:18:52
    /// </summary>
    public class MongoBaseRepository<TEntity> : IMongoDbBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly MonogoDbConfig _dbConifg;
        private readonly IMongoDatabaseProvider _databaseProvider;

        public MongoBaseRepository(IMongoDatabaseProvider databaseProvider, MonogoDbConfig dbConfig)
        {
            EnsureUtil.NotNull(databaseProvider, "IMongoDatabaseProvider");
            EnsureUtil.NotNull(dbConfig, "MonogoDbConfig");
            _databaseProvider = databaseProvider;
            _dbConifg = dbConfig;
        }

        protected MonogoDbConfig DbConfig { get { return _dbConifg; } }

        protected virtual IMongoDatabase Database
        {
            get { return _databaseProvider.GetDatabase(DbConfig); }
        }

        protected virtual IMongoCollection<TEntity> Collection
        {
            get
            {
                return Database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }

        /// <summary>
        /// 插入一条实体
        /// </summary>
        /// <param name="entity">实体信息</param>
        /// <returns>实体信息</returns>
        public virtual TEntity InsertOne(TEntity entity)
        {
            Collection.InsertOne(entity);
            return entity;
        }

        /// <summary>
        /// 异步插入一条实体
        /// </summary>
        /// <param name="entity">实体信息</param>
        /// <returns>实体信息</returns>
        public virtual async Task<TEntity> InsertOneAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        /// <summary>
        /// 插入多条实体
        /// </summary>
        /// <param name="entityList">实体列表</param>
        public virtual void InsertMany(IEnumerable<TEntity> entityList)
        {
            Collection.InsertMany(entityList);
        }

        /// <summary>
        /// 异步插入多条实体
        /// </summary>
        /// <param name="entityList">实体列表</param>
        /// <returns></returns>
        public virtual Task InsertManyAsync(IEnumerable<TEntity> entityList)
        {
            return Collection.InsertManyAsync(entityList);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="filter">删除的条件</param>
        /// <returns>true表示删除成功</returns>
        public virtual bool DeleteOne(Expression<Func<TEntity, bool>> filter)
        {
            var deleteResult = Collection.DeleteOne(filter);
            return deleteResult.DeletedCount > 0;
        }

        /// <summary>
        /// 异步删除一条数据
        /// </summary>
        /// <param name="filter">删除的条件</param>
        /// <returns>true表示删除成功</returns>
        public virtual async Task<bool> DeleteOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            var deleteResult = await Collection.DeleteOneAsync(filter);
            return deleteResult.DeletedCount > 0;
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="filter">删除的条件</param>
        /// <returns>删除的总记录数</returns>
        public virtual long DeleteMany(Expression<Func<TEntity, bool>> filter)
        {
            var deleteResult = Collection.DeleteMany(filter);
            return deleteResult.DeletedCount;
        }

        /// <summary>
        /// 异步删除多条数据
        /// </summary>
        /// <param name="filter">删除的条件</param>
        /// <returns>删除的总记录数</returns>
        public virtual async Task<long> DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
        {
            var deleteResult = await Collection.DeleteManyAsync(filter);
            return deleteResult.DeletedCount;
        }

        //public bool UpdateOne(Expression<Func<TEntity, bool>> filter,)
        /// <summary>
        /// 获取一条实体信息（获取不到则为空）
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>实体信息</returns>
        public virtual TEntity GetInfo(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// 异步获取一条实体信息（获取不到则为空）
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>实体信息</returns>
        public virtual Task<TEntity> GetInfoAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取全部实体
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return Collection.AsQueryable();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>列表</returns>
        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.Find(filter).ToEnumerable();
        }

        /// <summary>
        /// 异步获取列表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>列表</returns>
        public virtual Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.FindAsync(filter).ContinueWith((m) => { return m.Result.ToEnumerable(); });
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <returns>数量</returns>
        public virtual long Count()
        {
            return GetAll().Count();
        }

        /// <summary>
        /// 异步获取数量
        /// </summary>
        /// <returns>数量</returns>
        public virtual Task<long> CountAsync()
        {
            return Task.FromResult(Count());
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>数量</returns>
        public virtual long Count(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.Count(filter);
        }

        /// <summary>
        /// 异步获取数量
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>数量</returns>
        public virtual Task<long> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.CountAsync(filter);
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="filter">条件</param>
        /// <param name="sort">排序</param>
        /// <param name="pageIndex">当前页面</param>
        /// <param name="pageSize">页长</param>
        /// <param name="isDesc">是否倒叙排列</param>
        /// <param name="maxPageCount">最大页数</param>
        /// <returns>分页结果</returns>
        public virtual IPageResult<TEntity> PageQuery(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> sort, int pageIndex, int pageSize, bool isDesc, int? maxPageCount = null)
        {
            int totalCount = (int)Count(filter);
            IEnumerable<TEntity> data = null;
            if (isDesc)
            {
                data = Collection.Find(filter).SortByDescending(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToEnumerable();
            }
            else
            {
                data = Collection.Find(filter).SortBy(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToEnumerable();
            }
            return new PageResult<TEntity>(pageIndex, pageSize, totalCount, data, maxPageCount);
        }

        /// <summary>
        /// 异步获取分页信息
        /// </summary>
        /// <param name="filter">条件</param>
        /// <param name="sort">排序</param>
        /// <param name="pageIndex">当前页面</param>
        /// <param name="pageSize">页长</param>
        /// <param name="isDesc">是否倒叙排列</param>
        /// <param name="maxPageCount">最大页数</param>
        /// <returns>分页结果</returns>
        public virtual Task<IPageResult<TEntity>> PageQueryAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> sort, int pageIndex, int pageSize, bool isDesc, int? maxPageCount = null)
        {
            return Task.FromResult(PageQuery(filter, sort, pageIndex, pageSize, isDesc, maxPageCount: maxPageCount));
        }
    }
}