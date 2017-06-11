using System.ComponentModel.DataAnnotations;

namespace Monitor.WebManage.Models
{
    /// <summary>
    /// Copyright (C) 2017 yjq ��Ȩ���С�
    /// ������AccountModel.cs
    /// �����ԣ������ࣨ�Ǿ�̬��
    /// �๦����������¼
    /// ������ʶ��yjq 2017/6/11 0:08:19
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
        public string Code { get; set; }
    }
}