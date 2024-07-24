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
    } 
}
