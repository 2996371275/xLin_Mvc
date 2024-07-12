using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    /// <summary>
    /// Mono的单例类，尽量少实例化该类，全局的地方用即可
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static readonly object Lock = new object();
        private static bool _applicationIsQuitting = false;
        public static T Instance
        {
            get
            {
                if (_applicationIsQuitting)
                {

                    return null;
                }
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            return _instance;
                        }
                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<T>();
                            singleton.name = typeof(T).ToString();
                            DontDestroyOnLoad(singleton);
                        }
                    }

                    return _instance;
                }
            }
        }
    }
}
