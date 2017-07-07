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
    public class RequestStatistic
    {
        private ConcurrentQueue<TimeConsumerInfo> _timeConsumerQueue = new ConcurrentQueue<TimeConsumerInfo>();

        /// <summary>
        /// 调用方法名字
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// 消耗时间
        /// </summary>
        public double Millisecond { get; set; }

        /// <summary>
        /// 时间消耗类型
        /// </summary>
        public IEnumerable<TimeConsumerInfo> TimeConsumerList
        {
            get
            {
                return _timeConsumerQueue.ToArray();
            }
        }

        /// <summary>
        /// 添加缓存信息
        /// </summary>
        /// <param name="cacheInfo"></param>
        public void AddConsumerInfo(TimeConsumerInfo consumerInfo)
        {
            if (consumerInfo != null)
            {
                _timeConsumerQueue.Enqueue(consumerInfo);
            }
        }

        public override string ToString()
        {
            return this.ToJson();
        }
    }
}