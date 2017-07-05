using Monitor.TransDto.Admin;
using System.Threading.Tasks;

namespace Monitor.ICache
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IAuthorityCache.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：授权缓存接口类
    /// 创建标识：yjq 2017/7/5 15:07:14
    /// </summary>
    public interface IAuthorityCache
    {
        /// <summary>
        /// 设置登录失败次数
        /// </summary>
        /// <param name="userName">要设置的用户名</param>
        /// <returns></returns>
        long AddLoginFailedCount(string userName);

        /// <summary>
        /// 异步设置登录失败次数
        /// </summary>
        /// <param name="userName">要设置的用户名</param>
        /// <returns></returns>
        Task<long> AddLoginFailedCountAsync(string userName);

        /// <summary>
        /// 获取登录失败次数
        /// </summary>
        /// <param name="userName">要获取的用户名</param>
        /// <returns>失败次数</returns>
        long GetLoginFailedCount(string userName);

        /// <summary>
        /// 异步获取登录失败次数
        /// </summary>
        /// <param name="userName">要获取的用户名</param>
        /// <returns>失败次数</returns>
        Task<long> GetLoginFailedCountAsync(string userName);

        /// <summary>
        /// 添加授权Token
        /// </summary>
        /// <param name="token">token值</param>
        /// <param name="adminInfo">对应用户信息</param>
        /// <returns>成功返回true</returns>
        bool AddAuthorityToken(string token, AdminDto adminInfo);

        /// <summary>
        /// 异步添加授权Token
        /// </summary>
        /// <param name="token">token值</param>
        /// <param name="adminInfo">对应用户信息</param>
        /// <returns>成功返回true</returns>
        Task<bool> AddAuthorityTokenAsync(string token, AdminDto adminInfo);

        /// <summary>
        /// 移除授权token
        /// </summary>
        /// <param name="token">要移除的token</param>
        /// <returns>成功返回true</returns>
        bool RemoveAuthorityToken(string token);

        /// <summary>
        /// 异步移除授权token
        /// </summary>
        /// <param name="token">要移除的token</param>
        /// <returns>成功返回true</returns>
        Task<bool> RemoveAuthorityTokenAsync(string token);

        /// <summary>
        /// 判断是否存在token
        /// </summary>
        /// <param name="token">要判断的token值</param>
        /// <returns>存在返回true</returns>
        bool IsExistToken(string token);

        /// <summary>
        /// 异步判断是否存在token
        /// </summary>
        /// <param name="token">要判断的token值</param>
        /// <returns>存在返回true</returns>
        Task<bool> IsExistTokenAsync(string token);
    }
}