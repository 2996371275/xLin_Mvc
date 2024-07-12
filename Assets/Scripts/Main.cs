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
     
    }

    private void OnDestroy()
    {
        xLin.EventSystemManager.Instance.Dispose();
        xLin.TimerManager.Instance.Dispose();
    }

}
