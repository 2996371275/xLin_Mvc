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
                rt.anchorMin = new Vector2(0,0);
                rt.anchorMax = new Vector2(1, 1);
                rt.offsetMax = new Vector2(0, 0);
                rt.offsetMin = new Vector2(0, 0);
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type type = assembly.GetType(viewName);
                if (type != null)
                {
                   
                    object[] constructorArgs = { };
                    ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                    if (constructor != null)
                    {
                    
                        object instance = constructor.Invoke(null);
                        BaseView baseView = instance as BaseView;
                        baseView.Init(temp);
                        view = baseView;
                        viewInfo.baseView = view;

                    }
                }
            });
        }
    }
}
