using JQ.Result;
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
        /// 更新一条记录
        /// </summary>
        /// <param name="filter">条件</param>
        /// <param name="obj">更新内容</param>
        /// <param name="updateOptions">设置</param>
        /// <returns>记录数大于返回true</returns>
        bool UpdateOne(Expression<Func<TEntity, bool>> filter, object obj);

        /// <summary>
        /// 异步更新一条记录
        /// </summary>
        /// <param name="filter">条件</param>
        /// <param name="obj">更新内容</param>
        /// <param name="updateOptions">设置</param>
        /// <returns>记录数大于返回true</returns>
        Task<bool> UpdateOneAsync(Expression<Func<TEntity, bool>> filter, object obj);

        /// <summary>
        /// 更新记录信息
        /// </summary>
        /// <param name="filter">条件</param>
        /// <param name="obj">更新内容</param>
        /// <param name="updateOptions">设置</param>
        /// <returns>更新记录数</returns>
        long UpdateMany(Expression<Func<TEntity, bool>> filter, object obj);

        /// <summary>
        /// 异步更新记录信息
        /// </summary>
        /// <param name="filter">条件</param>
        /// <param name="obj">更新内容</param>
        /// <param name="updateOptions">设置</param>
        /// <returns>更新记录数</returns>
        Task<long> UpdateManyAsync(Expression<Func<TEntity, bool>> filter, object obj);

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
        /// 获取DTO（获取不到则为空）
        /// </summary>
        /// <typeparam name="TDto">DTO类型</typeparam>
        /// <param name="filter">条件</param>
        /// <param name="projectionExpression">映射表达式</param>
        /// <returns>DTO信息</returns>
        TDto GetDto<TDto>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TDto>> projectionExpression);

        /// <summary>
        /// 异步获取DTO（获取不到则为空）
        /// </summary>
        /// <typeparam name="TDto">DTO类型</typeparam>
        /// <param name="filter">条件</param>
        /// <param name="projectionExpression">映射表达式</param>
        /// <returns>DTO信息</returns>
        Task<TDto> GetDtoAsync<TDto>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TDto>> projectionExpression);

        /// <summary>
        /// 获取全部实体
        /// </summary>
        /// <typeparam name="TDto">类型</typeparam>
        /// <param name="projectionExpression">映射表达式</param>
        /// <returns>获取全部实体</returns>
        IEnumerable<TDto> GetDtoList<TDto>(Expression<Func<TEntity, TDto>> projectionExpression);

        /// <summary>
        /// 异步获取全部实体
        /// </summary>
        /// <typeparam name="TDto">类型</typeparam>
        /// <param name="projectionExpression">映射表达式</param>
        /// <returns>获取全部实体</returns>
        Task<IEnumerable<TDto>> GetDtoListAsync<TDto>(Expression<Func<TEntity, TDto>> projectionExpression);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TDto">实体类型</typeparam>
        /// <param name="filter">条件</param>
        /// <param name="projectionExpression">映射表达式</param>
        /// <returns>实体列表</returns>
        IEnumerable<TDto> GetDtoList<TDto>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TDto>> projectionExpression);

        /// <summary>
        /// 异步获取列表
        /// </summary>
        /// <typeparam name="TDto">实体类型</typeparam>
        /// <param name="filter">条件</param>
        /// <param name="projectionExpression">映射表达式</param>
        /// <returns>实体列表</returns>
        Task<IEnumerable<TDto>> GetDtoListAsync<TDto>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TDto>> projectionExpression);

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
        /// <typeparam name="TDto">返回结果类型</typeparam>
        /// <param name="filter">条件</param>
        /// <param name="sort">排序</param>
        /// <param name="pageIndex">当前页面</param>
        /// <param name="pageSize">页长</param>
        /// <param name="isDesc">是否倒叙排列</param>
        /// <param name="projectionExpression">映射表达式</param>
        /// <param name="maxPageCount">最大页数</param>
        /// <returns>分页结果</returns>
        IPageResult<TDto> PageQuery<TDto>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> sort, int pageIndex, int pageSize, bool isDesc, Expression<Func<TEntity, TDto>> projectionExpression, int? maxPageCount = null) where TDto : new();

        /// <summary>
        /// 异步获取分页信息
        /// </summary>
        /// <typeparam name="TDto">返回结果类型</typeparam>
        /// <param name="filter">条件</param>
        /// <param name="sort">排序</param>
        /// <param name="pageIndex">当前页面</param>
        /// <param name="pageSize">页长</param>
        /// <param name="isDesc">是否倒叙排列</param>
        /// <param name="projectionExpression">映射表达式</param>
        /// <param name="maxPageCount">最大页数</param>
        /// <returns>分页结果</returns>
        Task<IPageResult<TDto>> PageQueryAsync<TDto>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> sort, int pageIndex, int pageSize, bool isDesc, Expression<Func<TEntity, TDto>> projectionExpression, int? maxPageCount = null) where TDto : new();

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