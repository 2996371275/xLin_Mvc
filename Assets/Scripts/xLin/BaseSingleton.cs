using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    /// <summary>
    /// »ù´¡µ¥ÀýÀà
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseSingleton<T> where T:class, new()
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());
        public static T Instance
        {
            get { return _instance.Value; }
        }

        protected BaseSingleton() { }
    }
}
