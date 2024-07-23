using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin {
    public class Tool :BaseSingleton<Tool>
    {
        public Dictionary<string, UIElementConfig> LoadViewConfig(string sources)
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
                if (i > 1)
                {
                    UIElementConfig config = new UIElementConfig();
                    config.name = conlumnStrs.Length > 0 ? conlumnStrs[0]:null;
                    config.type = conlumnStrs.Length > 1 ? conlumnStrs[1]:null;
                    config.path = conlumnStrs.Length > 2 ?conlumnStrs[2]:null;
                    config.fontColor = conlumnStrs.Length > 3 ? conlumnStrs[3]:null;
                    config.texturePath = conlumnStrs.Length > 4 ? conlumnStrs[4]:null;
                    config.spritePath = conlumnStrs.Length > 5 ? conlumnStrs[5]:null;
                    config.fontSize = conlumnStrs.Length > 6 ? int.Parse(conlumnStrs[6]):0;
                    viewConfigs.Add(config.name, config);
                }
            }
            return viewConfigs;
        }
    } 
}
