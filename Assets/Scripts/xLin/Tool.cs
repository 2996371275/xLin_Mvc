using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin {
    public class Tool :BaseSingleton<Tool>
    {
        public Dictionary<string, ViewConfig> LoadViewConfig(string sources)
        {
            Dictionary<string, ViewConfig> viewConfigs = new Dictionary<string, ViewConfig>();
            string[] lineStrs = sources.Split('\n');
            for (int i=0;i<lineStrs.Length;i++)
            {

            }
            return viewConfigs;
        }
    } 
}
