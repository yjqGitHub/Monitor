using System;
using System.IO;

namespace JQ.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：FileUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/6/19 10:30:07
    /// </summary>
    public static class FileUtil
    {
        /// <summary>
        /// 获取当前项目的基目录
        /// </summary>
        /// <returns></returns>
        public static string GetDomianPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// 判断文件是否存在本地目录
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsExistsFile(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// 文件是否不存在本地目录
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsNotExistsFile(string filePath)
        {
            return !IsExistsFile(filePath);
        }
    }
}