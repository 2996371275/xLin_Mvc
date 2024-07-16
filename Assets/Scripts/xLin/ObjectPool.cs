using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    public class ObjectPool<T> where T : new()
    {
        private Stack<T> _pool;
        private int _maxSize;

        public ObjectPool(int maxSize)
        {
            _pool = new Stack<T>();
            _maxSize = maxSize;
        }

        public T Get()
        {
            if (_pool.Count > 0)
            {
                return _pool.Pop();
            }
            else
            {
                return new T();
            }
        }

        public void Recycle(T obj)
        {
            if (_pool.Count < _maxSize)
            {
                _pool.Push(obj);
            }
        }
    }
}
