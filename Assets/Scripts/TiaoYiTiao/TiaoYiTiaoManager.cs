using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiaoYiTiaoManager : xLin.MonoSingleton<TiaoYiTiaoManager>
{
   public void Init()
    {
        transform.tag = "ModelView";
        transform.gameObject.layer = 6;
        TiaoYiTiaoRoleModelView.Instance.Dispose();
        StartGame();
    }

    void StartGame()
    {
        TiaoYiTiaoRoleModelView.Instance.Init();
    }
    private void OnDestroy()
    {
        TiaoYiTiaoRoleModelView.Instance.Dispose();
    }
}
