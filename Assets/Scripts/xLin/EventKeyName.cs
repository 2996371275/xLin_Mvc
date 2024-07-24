using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    public struct EventKeyName
    {
        #region 基础事件
        public static string Init = "Init";
        public static string Awake = "Awake";//unity awake
        public static string Start = "Start";//unity Start
        public static string OnEnable = "OnEnable";//unity OnEnable
        public static string OnDisable = "OnDisable";//unity OnDisable
        public static string OnDestory = "OnDestory";//unity OnDestroy
        public static string ExitApplication = "ExitApplication";
        #endregion

        #region 自定义开发事件

        #endregion
    }
    public struct TimerKeyName
    {
        public static string MainStart = "MainStartTimer";
    }
}
