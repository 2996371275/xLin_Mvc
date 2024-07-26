using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using UnityEditor;

public class Main : xLin.MonoSingleton<Main>
{
    private void Awake()
    {
        xLin.EventSystemManager.Instance.Init();
        xLin.TimerManager.Instance.Init();
        xLin.Updater.Instance.Init();
        xLin.UIManager.Instance.Init();
        xLin.ControlerManager.Instance.Init();
        xLin.ModelView.Instance.Init();
        xLin.EventSystemManager.Instance.Add(xLin.EventKeyName.ExitApplication, () => {
            Debug.Log("关闭程序");
            Application.Quit();
#if UNITY_EDITOR
            // 停止播放模式
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
             
#endif
        });

    }

    private void Start()
    {
        xLin.TimerManager.Instance.Add(xLin.TimerKeyName.MainStart,1, () => {
            MainViewControler.Instance.OpenView("MainView");
        });
    }

    private void OnDestroy()
    {
        xLin.ModelView.Instance.Dispose();
        xLin.EventSystemManager.Instance.Dispose(); 
        xLin.TimerManager.Instance.Dispose();
        xLin.UIManager.Instance.Dispose();
    }

}
