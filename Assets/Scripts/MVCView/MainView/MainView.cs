using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : xLin.BaseView
{
    public override void Awake() {
        base.Awake();
    }
    public override void Start() {
        base.Start();
        UIElements["buttonText"].transform.GetComponent<TMPro.TMP_Text>().text = "¹Ø±Õ";
        UIElements["buttonImage"].transform.GetComponent<Button>().onClick.AddListener(() => {
            Debug.Log("¹Ø±Õ");
            xLin.EventSystemManager.Instance.DispatchEvent(xLin.EventKeyName.ExitApplication);
            Dispose();
        });
    }
    public override void Update() {
        base.Update();
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
