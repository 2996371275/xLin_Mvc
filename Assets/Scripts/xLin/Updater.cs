using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    /// <summary>
    /// È«¾ÖË¢ÐÂ
    /// </summary>
    public class Updater : MonoSingleton<Updater>
    {

        public void Init()
        {
         
        }
        private void Awake()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.Awake);
        }
        private void Start()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.Start);
        }
        private void Update()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.Update);
        }
        private void FixedUpdate()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.FixedUpdate);
        }
        private void LateUpdate()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.LateUpdate);
        }
        private void OnDisable()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.OnDisable);
        }
        private void OnEnable()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.OnEnable);
        }
        private void OnDestroy()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.OnDestory);
        }
    }
}
