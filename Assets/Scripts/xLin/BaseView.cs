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
        public Dictionary<string, UIElementConfig> UIElements = new Dictionary<string, UIElementConfig>();
        public virtual void Init(GameObject obj)
        {
            gameObject = obj;
            viewInfo = gameObject.GetComponent<ViewInfo>();
            GetViewConfig();

            Awake();
            Start();
            Updater.Instance.Add(UpdaterDef.update, Update);
            Updater.Instance.Add(UpdaterDef.fixedUpdate, FixedUpdate);
            Updater.Instance.Add(UpdaterDef.lateUpdate, LateUpdate);
        }
        public virtual void Awake()
        {

        }
        public virtual void Start()
        {

        }
        public virtual void Update()
        {
            if (gameObject == null)
            {
                return;
            }
        }
        public virtual void FixedUpdate()
        {
            if (gameObject == null)
            {
                return;
            }
        }
        public virtual void LateUpdate()
        {
            if (gameObject == null)
            {
                return;
            }
        }

        public virtual void OnEnable()
        {
            if (gameObject == null)
            {
                return;
            }

        }
        public virtual void OnDisable()
        {
            if (gameObject == null)
            {
                return;
            }

        }
        public virtual void GetViewConfig()
        {
            if (UIElements != null && UIElements.Count > 0)
            {

            }
            else
            {
                UIElements = Tool.Instance.LoadViewConfig(viewInfo.viewConfig.text, gameObject);
            }
        }
        public virtual void Dispose()
        {

            Updater.Instance.Remove(UpdaterDef.update, Update);
            Updater.Instance.Remove(UpdaterDef.fixedUpdate, FixedUpdate);
            Updater.Instance.Remove(UpdaterDef.lateUpdate, LateUpdate);
            UIElements.Clear();
            viewInfo = null;
            if (gameObject != null)
            {
                GameObject.Destroy(gameObject);
            }
            gameObject = null;
        }
    }
}
