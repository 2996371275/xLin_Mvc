using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    public class BaseView
    {
        public GameObject gameObject;
        public BaseView(GameObject obj)
        {
            gameObject = obj;
            EventSystemManager.Instance.Add(EventKeyName.Awake, Awake);
            EventSystemManager.Instance.Add(EventKeyName.Start, Start);
            EventSystemManager.Instance.Add(EventKeyName.OnDestory, OnDestroy);
            EventSystemManager.Instance.Add(EventKeyName.OnEnable, OnEnable);
            EventSystemManager.Instance.Add(EventKeyName.OnDisable, OnDisable);

            Updater.Instance.Add(UpdaterDef.update, Update);
            Updater.Instance.Add(UpdaterDef.fixedUpdate, FixedUpdate);
            Updater.Instance.Add(UpdaterDef.lateUpdate, LateUpdate);
        }
        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void OnDestroy() { }
        public virtual void FixedUpdate() { }
        public virtual void LateUpdate()
        {
        }

        public virtual void OnEnable() { }
        public virtual void OnDisable() { }

        public virtual void Dispose() {
            Updater.Instance.Remove(UpdaterDef.update, Update);
            Updater.Instance.Remove(UpdaterDef.fixedUpdate, FixedUpdate);
            Updater.Instance.Remove(UpdaterDef.lateUpdate, LateUpdate);
            EventSystemManager.Instance.Remove(EventKeyName.Awake, Awake);
            EventSystemManager.Instance.Remove(EventKeyName.Start, Start);
            EventSystemManager.Instance.Remove(EventKeyName.OnDestory, OnDestroy);
            EventSystemManager.Instance.Remove(EventKeyName.OnEnable, OnEnable);
            EventSystemManager.Instance.Remove(EventKeyName.OnDisable, OnDisable);
            GameObject.Destroy(gameObject);
        }
    }
}
