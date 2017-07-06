using JQ.Extensions;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace JQ.Statistics
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：MethodStatistic.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：方法统计
    /// 创建标识：yjq 2017/7/6 22:40:42
    /// </summary>
    public class MethodStatistic
    {
        private ConcurrentQueue<CacheStatistic> _cacheQueue = new ConcurrentQueue<CacheStatistic>();
        private ConcurrentQueue<NoSqlStatistic> _noSqlQueue = new ConcurrentQueue<NoSqlStatistic>();
        private ConcurrentQueue<SqlStatistic> _sqlQueue = new ConcurrentQueue<SqlStatistic>();

        /// <summary>
        /// 调用方法名字
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 消耗时间
        /// </summary>
        public double Millisecond { get; set; }

        /// <summary>
        /// 缓存执行列表
        /// </summary>
        public IEnumerable<CacheStatistic> CacheList
        {
            get
            {
                return _cacheQueue.ToArray();
            }
        }

        /// <summary>
        /// NoSql执行列表
        /// </summary>
        public IEnumerable<NoSqlStatistic> NoSqlList
        {
            get
            {
                return _noSqlQueue.ToArray();
            }
        }

        /// <summary>
        /// Sql执行列表
        /// </summary>
        public IEnumerable<SqlStatistic> SqlList
        {
            get
            {
                return _sqlQueue.ToArray();
            }
        }

        /// <summary>
        /// 添加缓存信息
        /// </summary>
        /// <param name="cacheInfo"></param>
        public void AddCacheInfo(CacheStatistic cacheInfo)
        {
            if (cacheInfo != null)
            {
                _cacheQueue.Enqueue(cacheInfo);
            }
        }

        /// <summary>
        /// 添加nosql信息
        /// </summary>
        /// <param name="noSqlInfo"></param>
        public void AddNoSqlInfo(NoSqlStatistic noSqlInfo)
        {
            if (noSqlInfo != null)
            {
                _noSqlQueue.Enqueue(noSqlInfo);
            }
        }

        /// <summary>
        /// 添加sql信息
        /// </summary>
        /// <param name="sqlInfo"></param>
        public void AddSqlInfo(SqlStatistic sqlInfo)
        {
            if (sqlInfo != null)
            {
                _sqlQueue.Enqueue(sqlInfo);
            }
        }

        public override string ToString()
        {
            return this.ToJson();
        }
    }
}