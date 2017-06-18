using Monitor.Domain.Model;

namespace Monitor.Domain.IDomainServer
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IAdminDomainServer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IAdminDomainServer
    /// 创建标识：yjq 2017/6/18 20:25:55
    /// </summary>
    public interface IAdminDomainServer
    {
        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        void LoginCheck(AdminInfo adminInfo, string pwd);
    }
}