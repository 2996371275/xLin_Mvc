using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace xLin
{
    public class BaseControler : BaseSingleton<BaseControler>
    {
        public BaseModel model;
        public BaseView view;
        public virtual void Init(BaseModel _model)
        {
            model = _model;
        }
        public virtual void OpenView(string viewName)
        {
            ResourcesManager.Instance.Load(PathDef.view, viewName, (gameObject) =>
            {
                GameObject temp = GameObject.Instantiate(gameObject as GameObject, Vector3.zero, Quaternion.identity);
                temp.name = viewName;
                var viewInfo = temp.transform.GetComponent<ViewInfo>();
                Transform tf = UIManager.Instance.UILayerToLayer(viewInfo.uiLayer).Find("Default");
                temp.transform.SetParent(tf);
                var rt = temp.transform.GetComponent<RectTransform>();
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type type = assembly.GetType(viewName);
                if (type != null)
                {
                    object[] constructorArgs = { gameObject };
                    ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(GameObject) });
                    if (constructor != null)
                    {
                    
                        object instance = constructor.Invoke(constructorArgs);
                        BaseView baseView = instance as BaseView;
                        view = baseView;
                        view.model = this.model;

                    }
                }
            });
        }

        public virtual void Dispose()
        {
            model.Dispose();
            if (view != null)
            {
                view.Dispose();
            }
        }
    }
}
