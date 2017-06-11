using System;

namespace JQ
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：JQDisposable.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：释放基类
    /// 创建标识：yjq 2017/6/10 23:06:14
    /// </summary>
    public class JQDisposable : IDisposable
    {
        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeCode()
        {
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCode();
            }
            _isDisposed = true;
        }

        ~JQDisposable()
        {
            Dispose(false);
        }
    }
}