using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TiaoYiTiaoRoleModelView:xLin.BaseSingleton<TiaoYiTiaoRoleModelView>
{

    Transform roleTrans;
    Transform oldPlateTrans;
    Transform curPlateTrans;
    Transform nextPlateTrans;
    bool canJump = false;
    float fallAnimDuration = 0.3f;
    float minValue = 4f;
    float maxValue = 8;
    Vector3 cameraToRolePos;
    float pressTime = 0f;
    float roleTransScaleY = 1;
    float oldPlateTransScaleY;
    float curPlateTransScaleY;
    float nextPlateTransScaleY;
    Vector3 tempScale;
    Vector3 rolePos;
    Vector3 endPos;
    Vector3 controlPos;
    float pressScale = 20;
    Vector3[] path;
    LineRenderer line;
    float pressTimeScale = 0.5f;

    void FallAnim(Transform trans,System.Action action)
    {
        float oldY = trans.localPosition.y;
        trans.localPosition = new Vector3(trans.localPosition.x, oldY + 10, trans.localPosition.z);
        trans.DOMoveY(oldY, fallAnimDuration).OnComplete(() =>
        {
            action?.Invoke();
        }).SetEase(Ease.OutCirc); ;
    }

    private void LoadRoleModelView()
    {
        LoadPlateModelView((plate) =>
        {
            curPlateTrans = plate;
            curPlateTransScaleY = curPlateTrans.transform.localScale.y;
            FallAnim(curPlateTrans, () => {
                xLin.ModelView.Instance.LoadModelView("role", (gameObject) => {
                    roleTrans = gameObject.transform;
                    roleTrans.tag = TiaoYiTiaoManager.Instance.transform.tag;
                    roleTrans.gameObject.layer = TiaoYiTiaoManager.Instance.transform.gameObject.layer;
                    roleTrans.SetParent(TiaoYiTiaoManager.Instance.transform);
                    roleTrans.localPosition = new Vector3(0, curPlateTrans.localScale.y, 0);
                    roleTransScaleY = roleTrans.localScale.y;
                    cameraToRolePos = roleTrans.position - Camera.main.transform.position;
                    var pos = roleTrans.position - cameraToRolePos;
                    Camera.main.transform.position = pos;
                    FallAnim(roleTrans, () => {
                        //角色准备完毕，生成第一步格子
                        LoadPlateModelView((nextPlate) => {
                            nextPlateTrans = nextPlate;
                            nextPlateTrans.transform.localPosition = new Vector3(0, 0, Random.Range(minValue* curPlateTrans.transform.localScale.x, maxValue));
                            nextPlateTransScaleY = nextPlateTrans.transform.localScale.y;
                            FallAnim(nextPlateTrans, () => {
                                canJump = true;
                            });
                        });
                    });
                });
            });
        });
    }

    private void LoadPlateModelView(System.Action<Transform> action)
    {
        int randomIndex = Random.Range(1, 5);
        xLin.ModelView.Instance.LoadModelView("plate"+ randomIndex.ToString(), (gameObject) => {

            var tTrans = gameObject.transform;
            tTrans.tag = TiaoYiTiaoManager.Instance.transform.tag;
            tTrans.gameObject.layer = TiaoYiTiaoManager.Instance.transform.gameObject.layer;
            tTrans.SetParent(TiaoYiTiaoManager.Instance.transform);
            action(tTrans);
        });
    }

    public void Init()
    {
        line = GameObject.Find("Line").transform.GetComponent<LineRenderer>();
        canJump = false;
        Reset();
        if (roleTrans != null)
        {
            GameObject.DestroyImmediate(roleTrans.gameObject);
        }
        LoadRoleModelView();
        xLin.Updater.Instance.Remove(xLin.UpdaterDef.update, Update);
        xLin.Updater.Instance.Add(xLin.UpdaterDef.update,Update);
    }

    void Update()
    {
        if (canJump)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                OnPress();
            }
            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
                OnPressUp();
            }
        }
    }

    void OnPress()
    {
        pressTime += (Time.deltaTime* pressTimeScale);
        float tRoleScaleY = roleTransScaleY - (roleTransScaleY* pressTime);
        float tCurTransCaleY = curPlateTransScaleY - (curPlateTransScaleY*pressTime);
        if (tRoleScaleY < roleTransScaleY / 2)
        {
            tRoleScaleY = roleTransScaleY/2;
        }
        if (tCurTransCaleY < curPlateTransScaleY / 2)
        {
            tCurTransCaleY = curPlateTransScaleY/2;
        }
        tempScale.Set(roleTrans.localScale.x, tRoleScaleY, roleTrans.localScale.z);
        roleTrans.localScale = tempScale;
        tempScale.Set(curPlateTrans.localScale.x, tCurTransCaleY, curPlateTrans.localScale.z);
        curPlateTrans.localScale = tempScale;
        rolePos.Set(roleTrans.localPosition.x, curPlateTrans.localScale.y,roleTrans.localPosition.z);
        roleTrans.localPosition = rolePos;
        CalCulateLine();

    }

    void CalCulateLine()
    {
        int dir = 1;
        if (curPlateTrans.localPosition.x == nextPlateTrans.position.x && curPlateTrans.localPosition.z != nextPlateTrans.position.z)
        {
            dir = 1;
        }
        if (curPlateTrans.localPosition.z == nextPlateTrans.position.z && curPlateTrans.localPosition.x != nextPlateTrans.position.x)
        {
            dir = 2;
        }
        switch (dir)
        {
            case 1:
                endPos.Set(nextPlateTrans.localPosition.x, nextPlateTrans.localPosition.y+ nextPlateTrans.lossyScale.y, nextPlateTrans.localPosition.z + (pressTime * pressScale));
                controlPos.Set(endPos.x, endPos.y + 10, endPos.z / 2);
                break;
            case 2:
                endPos.Set((nextPlateTrans.localPosition.x - pressTime * pressScale), nextPlateTrans.localPosition.y + nextPlateTrans.lossyScale.y, nextPlateTrans.localPosition.z);
                controlPos.Set(endPos.x / 2, endPos.y + 10, endPos.z);
                break;
        }
        path = xLin.Tool.Instance.Bezier2Path(50, roleTrans.localPosition, controlPos, endPos);
        line.positionCount = path.Length;
        line.startColor = Color.red;
        line.endColor = Color.blue;
        line.SetPositions(path);
    }
    void Reset()
    {
        pressTime = 0f;
        tempScale = new Vector3(0, 0, 0);
        rolePos = new Vector3(0, 0, 0);
        endPos = new Vector3(0, 0, 0);
        controlPos = new Vector3(0, 0, 0);
    }
    void OnPressUp()
    {
        line.positionCount = 0;
        canJump = false;
        if (pressTime <= 0.01f)
        {
            pressTime = 0f;
            canJump = true;
            Reset();
            return;
        }
        roleTrans.localScale = new Vector3(roleTrans.localScale.x, roleTransScaleY, roleTrans.localScale.z);
        nextPlateTrans.localScale = new Vector3(nextPlateTrans.localScale.x, nextPlateTransScaleY, nextPlateTrans.localScale.z);
        if (oldPlateTrans != null)
        {
            oldPlateTrans.localScale = new Vector3(oldPlateTrans.localScale.x, oldPlateTransScaleY, oldPlateTrans.localScale.z);
        }
        roleTrans.DOPath(path, 0.5f, PathType.CatmullRom).SetEase(Ease.OutCirc).OnComplete(() => {
            roleTrans.localPosition = path[path.Length - 1];
            oldPlateTrans = curPlateTrans;
            curPlateTrans = nextPlateTrans;
            LoadPlateModelView((trans) =>{
                nextPlateTrans = trans;
                int randValue = Random.Range(0,10);
                if (randValue >= 5)
                {
                    nextPlateTrans.transform.localPosition = new Vector3(curPlateTrans.localPosition.x,curPlateTrans.localPosition.y,Random.Range(minValue + curPlateTrans.localPosition.z,maxValue+curPlateTrans.localPosition.z));             
                }
                else
                {
                    nextPlateTrans.transform.localPosition = new Vector3(curPlateTrans.localPosition.x - Random.Range(minValue/2, maxValue/2), curPlateTrans.localPosition.y, curPlateTrans.localPosition.z);
                }
                var pos = roleTrans.position - cameraToRolePos;
                Camera.main.transform.DOMove(pos, 0.5f);
                FallAnim(nextPlateTrans, () => {
                    roleTransScaleY = roleTrans.localScale.y;
                    nextPlateTransScaleY = nextPlateTrans.localScale.y;
                    oldPlateTransScaleY = oldPlateTrans.localScale.y;
                    canJump = true;   
                    Reset();
                });
            });
        });
    
    }
   public void Dispose()
    {
        if (roleTrans != null)
        {
            GameObject.DestroyImmediate(roleTrans.gameObject);
        }
        if (oldPlateTrans != null)
        {
            GameObject.DestroyImmediate(oldPlateTrans.gameObject);
        }
        if (curPlateTrans != null)
        {
            GameObject.DestroyImmediate(curPlateTrans.gameObject);
        }
        if (nextPlateTrans != null)
        {
            GameObject.DestroyImmediate(nextPlateTrans.gameObject);
        }
       
    }
}
