using System.ComponentModel.DataAnnotations;

namespace Monitor.AdminManage.Models
{
    /// <summary>
    /// Copyright (C) 2017 yjq ��Ȩ���С�
    /// ������AccountModel.cs
    /// �����ԣ������ࣨ�Ǿ�̬��
    /// �๦��������AccountModel
    /// ������ʶ��yjq 2017/6/15 23:13:38
    /// </summary>
    public sealed class AccountModel
    {
        /// <summary>
        /// �û���
        /// </summary>
        [Required(ErrorMessage = "�û�������Ϊ��")]
        public string UserName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "���벻��Ϊ��")]
        public string Pwd { get; set; }

        /// <summary>
        /// ��֤��
        /// </summary>
        [Required(ErrorMessage = "��������֤��")]
        [StringLength(6, ErrorMessage = "��������ȷ����֤��")]
        public string Code { get; set; }
    }
}