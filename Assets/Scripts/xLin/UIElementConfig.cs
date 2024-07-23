using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace xLin
{
    [System.Serializable]
    public class UIElementConfig
    {
        public string name;
        public string type;
        public string path;
        public string fontColor;
        public string texturePath;
        public string spritePath;
        public int fontSize;

        public void GetElement<T>()
        {

        }
    }

}