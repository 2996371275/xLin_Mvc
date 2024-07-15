using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    public class ControlerManager:BaseSingleton<ControlerManager>
    {
        public void Init()
        {
            MainViewControler.Instance.Init(MainViewModel.Instance);
        }
    }
}
