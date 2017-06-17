using JQ.Utils;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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
    public class MongoBaseRepository<TEntity> where TEntity : class, new()
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

        public virtual IMongoDatabase Database
        {
            get { return _databaseProvider.GetDatabase(DbConfig); }
        }

        public virtual IMongoCollection<TEntity> Collection
        {
            get
            {
                return Database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }

        public virtual TEntity InsertOne(TEntity entity)
        {
            Collection.InsertOne(entity);
            return entity;
        }

        public virtual async Task<TEntity> InsertOneAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public virtual void InsertMany(IEnumerable<TEntity> entityList)
        {
            Collection.InsertMany(entityList);
        }

        public virtual Task InsertManyAsync(IEnumerable<TEntity> entityList)
        {
            return Collection.InsertManyAsync(entityList);
        }


        public virtual bool DeleteOne(Expression<Func<TEntity, bool>> filter)
        {
            var deleteResult = Collection.DeleteOne(filter);
            return deleteResult.DeletedCount > 0;
        }

        public virtual async Task<bool> DeleteOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            var deleteResult = await Collection.DeleteOneAsync(filter);
            return deleteResult.DeletedCount > 0;
        }

        public virtual long DeleteMany(Expression<Func<TEntity, bool>> filter)
        {
            var deleteResult = Collection.DeleteMany(filter);
            return deleteResult.DeletedCount;
        }

        public virtual async Task<long> DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
        {
            var deleteResult = await Collection.DeleteManyAsync(filter);
            return deleteResult.DeletedCount;
        }
        //public bool UpdateOne(Expression<Func<TEntity, bool>> filter,)

        public virtual TEntity GetInfo(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.Find(filter).FirstOrDefault();
        }

        public virtual Task<TEntity> GetInfoAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.Find(filter).FirstOrDefaultAsync();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Collection.AsQueryable();
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.Find(filter).ToEnumerable();
        }

        public virtual Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.FindAsync(filter).ContinueWith((m) => { return m.Result.ToEnumerable(); });
        }

        public virtual long Count()
        {
            return GetAll().Count();
        }

        public virtual Task<long> CountAsync()
        {
            return Task.FromResult(Count());
        }

        public virtual long Count(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.Count(filter);
        }

        public virtual Task<long> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.CountAsync(filter);
        }

        public virtual IEnumerable<TEntity> PageQuery(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> sort, int pageIndex, int pageSize, bool isDesc)
        {
            long totalCount = Count(filter);
            if (isDesc)
            {
                return Collection.Find(filter).SortByDescending(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToEnumerable();
            }
            else
            {
                return Collection.Find(filter).SortBy(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToEnumerable();
            }
        }
    }
}
