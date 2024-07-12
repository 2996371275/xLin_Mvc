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
        xLin.TimerManager.Instance.Add("timer1", 1, () =>
        {
            Debug.Log("timer1");
        },true);
     
    }

    private void OnDestroy()
    {
        xLin.EventSystemManager.Instance.Dispose();
        xLin.TimerManager.Instance.Dispose();
    }

}
