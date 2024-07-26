using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin {
    public class Tool :BaseSingleton<Tool>
    {
        public Dictionary<string, UIElementConfig> LoadViewConfig(string sources,GameObject gameObject)
        {
            Dictionary<string, UIElementConfig> viewConfigs = new Dictionary<string, UIElementConfig>();
            string[] rowStr = sources.Split('\n');
            string[] types ;
            for (int i=0;i< rowStr.Length;i++)
            {
                string[] conlumnStrs = rowStr[i].Split('\t');
                if (i == 0)
                {
                    types = conlumnStrs;
                }
                if (i > 2)
                {
                    UIElementConfig config = new UIElementConfig();
                    config.name = (conlumnStrs.Length > 0 && !string.IsNullOrEmpty(conlumnStrs[0])) ? conlumnStrs[0]:null;
                    config.type = (conlumnStrs.Length > 1 && !string.IsNullOrEmpty(conlumnStrs[1])) ? conlumnStrs[1]:null;
                    config.path = (conlumnStrs.Length > 2 && !string.IsNullOrEmpty(conlumnStrs[2])) ?conlumnStrs[2]:null;
                    config.fontColor = (conlumnStrs.Length > 3 && !string.IsNullOrEmpty(conlumnStrs[3])) ? conlumnStrs[3]:null;
                    config.texturePath = (conlumnStrs.Length > 4 && !string.IsNullOrEmpty(conlumnStrs[4])) ? conlumnStrs[4]:null;
                    config.spritePath = (conlumnStrs.Length > 5 && !string.IsNullOrEmpty(conlumnStrs[5])) ? conlumnStrs[5]:null;
                    config.fontSize = (conlumnStrs.Length > 6 && !string.IsNullOrEmpty(conlumnStrs[6]) && conlumnStrs[6] != "\r" && conlumnStrs[6] != "") ? int.Parse(conlumnStrs[6]):0;
                    config.SetElement(gameObject);
                    viewConfigs.Add(config.name, config);
                }
            }
            return viewConfigs;
        }

        //»ñÈ¡¶þ½×±´Èû¶ûÇúÏßÂ·¾¶Êý×é
        public Vector3[] Bezier2Path(int _pointCount,Vector3 startPos, Vector3 controlPos, Vector3 endPos)
        {
            Vector3[] path = new Vector3[(int)_pointCount];
            for (int i = 1; i <= _pointCount; i++)
            {
                float t = (float)i / _pointCount;
                path[i - 1] = Bezier2(startPos, controlPos, endPos, t);
            }
            return path;
        }
        // 2½×±´Èû¶ûÇúÏß
        public static Vector3 Bezier2(Vector3 startPos, Vector3 controlPos, Vector3 endPos, float t)
        {
            return (1 - t) * (1 - t) * startPos + 2 * t * (1 - t) * controlPos + t * t * endPos;
        }

        // 3½×±´Èû¶ûÇúÏß
        public static Vector3 Bezier3(Vector3 startPos, Vector3 controlPos1, Vector3 controlPos2, Vector3 endPos, float t)
        {
            float t2 = 1 - t;
            return t2 * t2 * t2 * startPos
                + 3 * t * t2 * t2 * controlPos1
                + 3 * t * t * t2 * controlPos2
                + t * t * t * endPos;
        }
    } 
}
