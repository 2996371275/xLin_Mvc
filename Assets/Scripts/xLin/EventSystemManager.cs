using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    /// <summary>
    /// 事件管理器
    /// </summary>
    public class EventSystemManager:BaseSingleton<EventSystemManager>
    {

        private Dictionary<string, System.Delegate> events;

        public void Init()
        {
            events = new Dictionary<string, System.Delegate>();
        }
        public virtual void Add<T>(string key, System.Action<T> eventHandler)
        {
            if (events.ContainsKey(key))
            {
                events[key] = System.Delegate.Combine(events[key], eventHandler);
            }
            else
            {
                events.Add(key, eventHandler);
            }
        }
        public virtual void Add(string key, System.Action eventHandler)
        {
            if (events.ContainsKey(key))
            {
                events[key] = System.Delegate.Combine(events[key], eventHandler);
            }
            else
            {
                events.Add(key, eventHandler);
            }
        }

        public virtual void Remove<T>(string key, System.Action<T> eventHandler)
        {
            if (events.ContainsKey(key))
            {
                events[key] = System.Delegate.Remove(events[key], eventHandler);
            }
        }
        public virtual void Remove(string key, System.Action eventHandler)
        {
            if (events.ContainsKey(key))
            {
                events[key] = System.Delegate.Remove(events[key], eventHandler);
            }
        }
        public virtual void RemoveAll(string key)
        {
            if (events.ContainsKey(key))
            {
                events.Remove(key);
            }
        }

        public virtual void DispatchEvent<T>(string key, T value)
        {
            if (events.ContainsKey(key))
            {
                if (events[key] is System.Action<T> action)
                {
                    action(value);
                }
            }
     
        }
        public virtual void DispatchEvent(string key)
        {
            if (events.ContainsKey(key))
            {
                if (events[key] is System.Action action)
                {
                    action();
                }
             
            }
        }

        public void Dispose()
        {
            events.Clear();
        }

    }
}
