using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainView : xLin.BaseView
{
    public MainView(GameObject obj) : base(obj)
    {
    }
    public override void Awake() {
        base.Awake();
    }
    public override void Start() {
        base.Start();
    }
    public override void Update() {
        base.Update();
    }
    public override void OnDestroy() {
        base.OnDestroy();
    }
    public override void FixedUpdate() {
        base.FixedUpdate();
    }
    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void OnEnable() {
        base.OnEnable();
    }
    public override void OnDisable() {
        base.OnDisable();

    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
