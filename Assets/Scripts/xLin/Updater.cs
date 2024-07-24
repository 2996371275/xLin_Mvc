using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{

    public enum UpdaterDef
    {
        update = 0,
        fixedUpdate = 1,
        lateUpdate = 2,
    }
    /// <summary>
    /// È«¾ÖË¢ÐÂ
    /// </summary>
    public class Updater : MonoSingleton<Updater>
    {

        private Dictionary<UpdaterDef, System.Action> updaters = new Dictionary<UpdaterDef, System.Action>();
        private Dictionary<UpdaterDef, System.Action> fixedUpdaters = new Dictionary<UpdaterDef, System.Action>();
        private Dictionary<UpdaterDef, System.Action> lateUpdaters = new Dictionary<UpdaterDef, System.Action>();

        public void Init()
        {
        }
        private void Awake()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.Awake);
        }
        private void Start()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.Start);
        }
        private void Update()
        {
            if (Updater.Instance != null)
            {
                InvokeActions(updaters);
            }
        }
        private void FixedUpdate()
        {
            if (Updater.Instance != null)
            {
                InvokeActions(fixedUpdaters);
            }
        }
        private void LateUpdate()
        {     
            if (Updater.Instance != null)          
            {               
                InvokeActions(lateUpdaters);     
            }    
        }
        private void OnDisable()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.OnDisable);
        }
        private void OnEnable()
        {
            EventSystemManager.Instance.DispatchEvent(EventKeyName.OnEnable);
        }
        private void OnDestroy()
        {
            
            updaters.Clear();
            fixedUpdaters.Clear();
            lateUpdaters.Clear();
        }
        private void InvokeActions(Dictionary<UpdaterDef, System.Action> actions)
        {
            List<System.Action> actionList = new List<System.Action>(actions.Values);
            foreach (var action in actionList)
            {
                action?.Invoke();
            }
        }

        public void Add(UpdaterDef def,System.Action action)
        {
            var dict = updaters;
            switch (def)
            {
                case UpdaterDef.update:
                    dict = updaters;
                    break;
                case UpdaterDef.fixedUpdate:
                    dict = fixedUpdaters;
                    break;
                case UpdaterDef.lateUpdate:
                    dict = lateUpdaters;
                    break;
                default:break;
            }
            if (dict.ContainsKey(def))
            {
                dict[def] += action;

            }
            else
            {
                dict.Add(def, action);
            }
        }
        public void Remove(UpdaterDef def,System.Action action)
        {
            var dict = updaters;
            switch (def)
            {
                case UpdaterDef.update:
                    dict = updaters;
                    break;
                case UpdaterDef.fixedUpdate:
                    dict = fixedUpdaters;
                    break;
                case UpdaterDef.lateUpdate:
                    dict = lateUpdaters;
                    break;
                default: break;
            }
            if (dict.ContainsKey(def))
            {
                dict[def] -= action;

            }
        }
    }
}
