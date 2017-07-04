using JQ.Utils;
using MongoDB.Driver;

namespace JQ.MongoDb.Extensions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：UpdateExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：Mongo更新扩展类
    /// 创建标识：yjq 2017/6/20 16:42:43
    /// </summary>
    public static class UpdateExtension
    {
        /// <summary>
        /// 将object转为UpdateDefinition（字段值必须要与库中一致）
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="obj">要转换的对象</param>
        /// <returns>UpdateDefinition</returns>
        public static UpdateDefinition<TEntity> ToUpdate<TEntity>(this object obj)
        {
            UpdateDefinition<TEntity> updateDefinition = null;
            var properties = PropertyUtil.GetPropertyInfos(obj);
            foreach (var property in properties)
            {
                if (updateDefinition == null)
                {
                    updateDefinition = Builders<TEntity>.Update.Set(property.Name, property.GetValue(obj, null));
                }
                else
                {
                    updateDefinition = updateDefinition.Set(property.Name, property.GetValue(obj, null));
                }
            }
            return updateDefinition;
        }
    }
}