using JQ.MongoDb;
using JQ.Utils;

namespace Monitor.Infrastructure.Mongo
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MonogoDbConfigUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MonogoDb配置文件帮助类
    /// 创建标识：yjq 2017/6/23 13:35:43
    /// </summary>
    public sealed class MonogoDbConfigUtil
    {
        /// <summary>
        /// 获取Mongodb的默认配置信息
        /// </summary>
        /// <returns></returns>
        public static MonogoDbConfig GetDefaultConfig()
        {
            //MonogoDbConfig.CreateConfig("mongodb://yjq:123456@localhost:27017/Monitor");
            return MonogoDbConfig.CreateConfig(ConfigUtil.GetValue("MonogoDbConfig", memberName: "RepositoryConstant.MonogoDbConfig"));
        }
    }
}