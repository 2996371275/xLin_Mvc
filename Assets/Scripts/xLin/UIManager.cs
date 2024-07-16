using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    public class UIManager : BaseSingleton<UIManager>
    {
        public Transform uiDefault;
        public Transform uiTop;
        public Transform uiFocus;
        public Transform uiTips;

        public void Init()
        {
            uiDefault = GameObject.Find("Canvas/Default").transform;
            uiTop = GameObject.Find("Canvas/TopUI").transform;
            uiFocus = GameObject.Find("Canvas/Focus").transform;
            uiTips = GameObject.Find("Canvas/Tips").transform;
        }
        /*
         * "Default", "TopUI", "Focus", "Tips"
         */

        public Transform UILayerToLayer(string _layer)
        {
            Transform tf = uiDefault;
            switch (_layer)
            {
                case "Default":
                    tf = uiDefault;
                    break;
                case "TopUI":
                    tf = uiTop;
                    break;
                case "Focus":
                    tf = uiFocus;
                    break;
                case "Tips":
                    tf = uiTips;
                    break;
            }
            return tf;
        }

        public void Dispose()
        {

        }

    }
}
