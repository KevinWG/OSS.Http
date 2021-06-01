﻿using System;
using System.Threading.Tasks;

namespace OSS.Tools.DataFlow
{
    /// <summary>
    ///  数据的订阅者
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public interface IDataSubscriber<TData>
    {
        /// <summary>
        /// 弹出数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns>是否弹出成功</returns>
        Task<bool> Subscribe(TData data);
    }

    internal class InterDataSubscriber<TData> : IDataSubscriber<TData>
    {
        private readonly Func<TData, Task<bool>> _subscriber;

        internal InterDataSubscriber(Func<TData, Task<bool>> subscribeFunc)
        {
            if (subscribeFunc == null)
            {
                throw new ArgumentNullException("Func<TData, Task<bool>> poper 方法不能为空！");
            }
            _subscriber = subscribeFunc;
        }

        public Task<bool> Subscribe(TData data)
        {
            return _subscriber.Invoke(data);
        }
    }
}