using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin {
    public class TimerManager : BaseSingleton<TimerManager>
    {
        private class xLinTimer
        {
            public System.Action action;
            public float duration = 0f;
            public float elapsedTime = 0f;
            public bool isPause = false;
            public string name;
            public bool isLoop = false;
            public bool isLoopOver = false;

            public xLinTimer(string _name,float _duration, System.Action _action)
            {
                name = _name;
                action = _action;
                duration = _duration;
            }
            public xLinTimer(string _name, float _duration, System.Action _action,bool _isLoop)
            {
                name = _name;
                action = _action;
                duration = _duration;
                isLoop = _isLoop;
            }
            public void Update()
            {
                if (isPause)
                {
                    return;
                }
                else
                {
                    elapsedTime += Time.deltaTime;
                    if (isLoop)
                    {
                        if (isLoopOver)
                        { 
                            TimerManager.Instance.Remove(name);
                        }
                        else
                        {
                            if (elapsedTime >= duration)
                            {
                                elapsedTime = 0f;
                                action?.Invoke();
                            }
                           }
                    }else
                    {
                        if (elapsedTime >= duration)
                        {
                            action?.Invoke();
                            TimerManager.Instance.Remove(name);
                        }
                    }
                }
            }
        }

        private Dictionary<string, xLinTimer> timers;

        public void Init()
        {
            timers = new Dictionary<string, xLinTimer>();
        }
        public virtual void Add(string name, float duration, System.Action action)
        {
            if (timers.ContainsKey(name))
            {  
                return;
            }

            xLinTimer timer = new xLinTimer(name,duration, action);
            timers.Add(name, timer);
            EventSystemManager.Instance.Add(EventKeyName.Update, timers[name].Update);
        }
        public virtual void Add(string name, float duration, System.Action action,bool isLoop)
        {
            if (timers.ContainsKey(name))
            {
                return;
            }

            xLinTimer timer = new xLinTimer(name, duration, action, isLoop);
            timers.Add(name, timer);
            EventSystemManager.Instance.Add(EventKeyName.Update, timers[name].Update);
        }

        public void Remove(string name)
        {
            if (timers.ContainsKey(name))
            {
                EventSystemManager.Instance.Remove(EventKeyName.Update,timers[name].Update);
                timers.Remove(name);
            }

        }

        public void Pause(string name)
        {
            if (timers.ContainsKey(name))
            {
                timers[name].isPause = true;
            }

        }

        public void Play(string name)
        {
            if (timers.ContainsKey(name))
            {
                timers[name].isPause = false;
            }
        }

        public void Dispose()
        {
            timers.Clear();
        }
    }
}
