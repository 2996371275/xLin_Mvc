using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    public class ViewInfo : MonoBehaviour
    {
        [StringDropdown("Default", "TopUI", "Focus", "Tips")]
        public string uiLayer = "Default";
        public int order = 0;
        public bool addStack = false;
        public TextAsset viewConfig;
        public BaseView baseView;
        private void OnDisable()
        {
            if (baseView != null)
            {
                baseView.OnDisable();
            }
        }
        private void OnEnable()
        {
            if (baseView != null)
            {
                baseView.OnEnable();
            }
        }
    }
}
