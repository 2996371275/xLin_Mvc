using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace xLin
{
    public class BaseView
    {
        public GameObject gameObject;
        ViewInfo viewInfo;
        public Dictionary<string, ViewConfig> viewConfigs;
        public BaseView()
        {
            EventSystemManager.Instance.Add(EventKeyName.Awake, Awake);
            EventSystemManager.Instance.Add(EventKeyName.Start, Start);
            EventSystemManager.Instance.Add(EventKeyName.OnDestory, OnDestroy);
            EventSystemManager.Instance.Add(EventKeyName.OnEnable, OnEnable);
            EventSystemManager.Instance.Add(EventKeyName.OnDisable, OnDisable);

            Updater.Instance.Add(UpdaterDef.update, Update);
            Updater.Instance.Add(UpdaterDef.fixedUpdate, FixedUpdate);
            Updater.Instance.Add(UpdaterDef.lateUpdate, LateUpdate);
          
        }
        public virtual void Init(GameObject obj)
        {
            gameObject = obj;
            viewInfo = gameObject.GetComponent<ViewInfo>();
            GetViewConfig();
        }
        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() {
            if (!(gameObject!=null && gameObject.activeInHierarchy))
            {
                return;
            }
        }
        public virtual void OnDestroy() {
            Dispose();
        }
        public virtual void FixedUpdate() {
            if (!(gameObject != null && gameObject.activeInHierarchy))
            {
                return;
            }
        }
        public virtual void LateUpdate()
        {
            if (!(gameObject != null && gameObject.activeInHierarchy))
            {
                return;
            }
        }

        public virtual void OnEnable() { }
        public virtual void OnDisable() { }
        public virtual void GetViewConfig()
        {
            try {
                if (viewConfigs!=null && viewConfigs.Count > 0) {
                    
                }
                else
                {

                    viewConfigs = Tool.Instance.LoadViewConfig(viewInfo.viewConfig.text); 
                }

            } catch (System.Exception ex)
            {
                Debug.LogWarning(ex.Message);
            }
        }
        public virtual void Dispose() {
            Updater.Instance.Remove(UpdaterDef.update, Update);
            Updater.Instance.Remove(UpdaterDef.fixedUpdate, FixedUpdate);
            Updater.Instance.Remove(UpdaterDef.lateUpdate, LateUpdate);
            EventSystemManager.Instance.Remove(EventKeyName.Awake, Awake);
            EventSystemManager.Instance.Remove(EventKeyName.Start, Start);
            EventSystemManager.Instance.Remove(EventKeyName.OnDestory, OnDestroy);
            EventSystemManager.Instance.Remove(EventKeyName.OnEnable, OnEnable);
            EventSystemManager.Instance.Remove(EventKeyName.OnDisable, OnDisable);
            viewConfigs.Clear();
            viewInfo = null;
            if (gameObject.activeInHierarchy && gameObject != null) {
                GameObject.Destroy(gameObject); 
            }
            gameObject = null;
        }
    }
}
