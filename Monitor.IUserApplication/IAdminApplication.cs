using JQ.Result;
using Monitor.TransDto.Admin;

namespace Monitor.IUserApplication
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IAdminApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IAdminApplication接口
    /// 创建标识：yjq 2017/6/19 11:39:29
    /// </summary>
    public interface IAdminApplication
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>用户信息</returns>
        OperateResult<AdminDto> Login(string userName, string pwd);
    }
}