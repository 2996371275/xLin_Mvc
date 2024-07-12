using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xLin
{
    public class BaseView
    {
        public GameObject gameObject;
        public BaseView(GameObject obj)
        {
            gameObject = obj;
        }
        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void OnDestroy() { }
        public virtual void FixedUpdate() { }
        public virtual void OnEnable() { }
        public virtual void OnDisEnable() { }

        public virtual void Dispose() { }
    }
}
