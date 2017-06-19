using JQ.Configurations;

namespace Monitor.AdminManage.App_Start
{
    /// <summary>
    /// Copyright (C) 2017 yjq ��Ȩ���С�
    /// ������BootStrapper.cs
    /// �����ԣ������ࣨ�Ǿ�̬��
    /// �๦��������BootStrapper
    /// ������ʶ��yjq 2017/6/15 23:11:49
    /// </summary>
    public static class BootStrapper
    {
        /// <summary>
        /// ����
        /// </summary>
        public static void Install()
        {

            JQConfiguration.Install(
                domainName: "Monitor",
                validateCodeSalt: "Monitor.ValidateCode",
                isStartConfigWatch: true,
                validateCookieKey: "Monitor.ValidateCode"
                ).UseDefaultConfig();
        }

        /// <summary>
        /// ֹͣ
        /// </summary>
        public static void UnInstall()
        {
            JQConfiguration.UnInstall();
        }
    }
}