using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class Main : xLin.MonoSingleton<Main>
{
    private void Awake()
    {
        xLin.EventSystemManager.Instance.Init();
        xLin.TimerManager.Instance.Init();
        xLin.Updater.Instance.Init();
        xLin.UIManager.Instance.Init();
        xLin.ControlerManager.Instance.Init();
    }

    private void Start()
    {
        MainViewControler.Instance.OpenView("MainView");
    }

    private void OnDestroy()
    {
        xLin.TimerManager.Instance.Dispose();
        xLin.UIManager.Instance.Dispose();
        xLin.EventSystemManager.Instance.Dispose();
    }

}
