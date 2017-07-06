using JQ.Result;
using System.Threading.Tasks;

namespace Monitor.IUserApplication
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IAuthorityApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IAuthorityApplication
    /// 创建标识：yjq 2017/7/5 20:44:53
    /// </summary>
    public interface IAuthorityApplication
    {
        /// <summary>
        /// 用户授权，成功返回token
        /// </summary>
        /// <param name="appId">授权站点ID</param>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>成功返回token</returns>
        Task<OperateResult<string>> AuthorityAsync(string appId, string userName, string pwd);

        /// <summary>
        /// 校验token是否有效
        /// </summary>
        /// <param name="token">需要校验的token</param>
        /// <returns>校验结果</returns>
        OperateResult CheckTokenIsAvailable(string token);
    }
}