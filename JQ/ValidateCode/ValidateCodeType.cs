using System.ComponentModel;

namespace JQ.ValidateCode
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ValidateCodeType.cs
    /// 类属性：枚举
    /// 类功能描述：验证码类型
    /// 创建标识：yjq 2017/6/10 10:26:58
    /// </summary>
    public enum ValidateCodeType
    {
        /// <summary>
        /// 数字
        /// </summary>
        [Description("数字")]
        Number = 0,

        /// <summary>
        /// 数字和字母
        /// </summary>
        [Description("数字和字母")]
        NumberAndLetter = 1,

        /// <summary>
        /// 汉字
        /// </summary>
        [Description("汉字")]
        ChineseCharacter = 2
    }
}