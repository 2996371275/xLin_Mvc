using System.Collections;
using System.Collections.Generic;
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
        public virtual void Open(string viewName)
        {
            ResourcesManager.Instance.Load(PathDef.view, viewName, (gameObject) =>
            {
                GameObject temp = gameObject as GameObject;
                temp.name = viewName;
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
