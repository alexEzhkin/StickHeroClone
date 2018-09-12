using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunScript1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static RunScript1 instance;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (BridgeScript1.instance != null)
        {
            Debug.Log("aaa");
            //BridgeScript1.instance.SePower(true);
            BridgeScript1.instance.BuildBridge(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (BridgeScript1.instance != null)
        {
            //BridgeScript1.instance.SePower(false);
            BridgeScript1.instance.BuildBridge(false);
            //if(PlayerScript.instance != null)
            //{
            //    PlayerScript.instance.SetPower(false);
            //}
        }
    }

    public void StopAll()
    {
        var pointer = GetComponents<IPointerUpHandler>();
        if (pointer != null)
        {
            foreach (var p in pointer)
            {
                var mp = p as MonoBehaviour;
                if (mp != null)
                {
                    mp.enabled = false;
                }
            }
        }
    }

    public void StartAll()
    {
        var pointer = GetComponents<IPointerUpHandler>();
        if (pointer != null)
        {
            foreach (var p in pointer)
            {
                var mp = p as MonoBehaviour;
                if (mp != null)
                {
                    mp.enabled = true;
                }
            }
        }
    }
}
