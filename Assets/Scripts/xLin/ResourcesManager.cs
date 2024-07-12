using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin{ 

    /// <summary>
    /// 各类资源路径结构体
    /// </summary>
    public struct Path
    {
        public static string view = "View/";
        public static string texture = "Texture/";
        public static string prefab = "Prefabs/";
    }
    public class ResourcesManager:BaseSingleton<ResourcesManager>
    {
        public void Load(Path pathType,string path, System.Action<Object> onCpmplete)
        {
            string loadPath = pathType + path;
            try
            {
                Updater.Instance.StartCoroutine(LoadAsync(loadPath,onCpmplete));
             
            }
            catch(System.Exception ex)
            {
                Debug.LogWarning("Load Error:"+ex.Message);
            }
        }

        IEnumerator LoadAsync(string path,System.Action<Object> complete)
        {
            ResourceRequest request = Resources.LoadAsync(path);
            while (!request.isDone)
            {
            
                yield return null;
            }
            complete?.Invoke(request.asset);
        }
    }
}

