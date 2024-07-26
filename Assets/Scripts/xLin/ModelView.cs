using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    /// <summary>
    /// 管理3D场景的模型
    /// </summary>
    public class ModelView:BaseSingleton<ModelView>
    {
        public void Init()
        {
           
        }
        public void LoadModelView(string modelName, System.Action<GameObject> onCpmplete)
        {
            ResourcesManager.Instance.Load(PathDef.modelView, modelName, (obj) => {
                GameObject temp = obj as GameObject;
                GameObject instanceObj = GameObject.Instantiate(temp, Vector3.zero, Quaternion.identity);
                instanceObj.name = modelName;
                onCpmplete?.Invoke(instanceObj);
            });
        }

        public void Dispose()
        {

        }
    }
}
