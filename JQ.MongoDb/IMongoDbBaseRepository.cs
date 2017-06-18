﻿using JQ.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JQ.MongoDb
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IMongoDbBaseRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IMongoDbBaseRepository
    /// 创建标识：yjq 2017/6/18 12:18:09
    /// </summary>
    public interface IMongoDbBaseRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 插入一条实体
        /// </summary>
        /// <param name="entity">实体信息</param>
        /// <returns>实体信息</returns>
        TEntity InsertOne(TEntity entity);

        /// <summary>
        /// 异步插入一条实体
        /// </summary>
        /// <param name="entity">实体信息</param>
        /// <returns>实体信息</returns>
        Task<TEntity> InsertOneAsync(TEntity entity);

        /// <summary>
        /// 插入多条实体
        /// </summary>
        /// <param name="entityList">实体列表</param>
        void InsertMany(IEnumerable<TEntity> entityList);

        /// <summary>
        /// 异步插入多条实体
        /// </summary>
        /// <param name="entityList">实体列表</param>
        /// <returns></returns>
        Task InsertManyAsync(IEnumerable<TEntity> entityList);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="filter">删除的条件</param>
        /// <returns>true表示删除成功</returns>
        bool DeleteOne(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 异步删除一条数据
        /// </summary>
        /// <param name="filter">删除的条件</param>
        /// <returns>true表示删除成功</returns>
        Task<bool> DeleteOneAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="filter">删除的条件</param>
        /// <returns>删除的总记录数</returns>
        long DeleteMany(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 异步删除多条数据
        /// </summary>
        /// <param name="filter">删除的条件</param>
        /// <returns>删除的总记录数</returns>
        Task<long> DeleteManyAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 获取一条实体信息（获取不到则为空）
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>实体信息</returns>
        TEntity GetInfo(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 异步获取一条实体信息（获取不到则为空）
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>实体信息</returns>
        Task<TEntity> GetInfoAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 获取全部实体
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>列表</returns>
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 异步获取列表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>列表</returns>
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <returns>数量</returns>
        long Count();

        /// <summary>
        /// 异步获取数量
        /// </summary>
        /// <returns>数量</returns>
        Task<long> CountAsync();

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>数量</returns>
        long Count(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 异步获取数量
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>数量</returns>
        Task<long> CountAsync(Expression<Func<TEntity, bool>> filter);

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
        IPageResult<TEntity> PageQuery(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> sort, int pageIndex, int pageSize, bool isDesc, int? maxPageCount = null);

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
        Task<IPageResult<TEntity>> PageQueryAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> sort, int pageIndex, int pageSize, bool isDesc, int? maxPageCount = null);
    }
}