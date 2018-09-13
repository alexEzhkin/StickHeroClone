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
            BridgeScript1.instance.BuildBridge(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (BridgeScript1.instance != null)
        {
            BridgeScript1.instance.BuildBridge(false);
        }
    }

    public void StopAll()
    {
        var pointer = GetComponents<IPointerUpHandler>();
        if (pointer != null)
        {
            foreach (var item in pointer)
            {
                var poindHandler = item as MonoBehaviour;
                if (poindHandler != null)
                {
                    poindHandler.enabled = false;
                }
            }
        }
    }

    public void StartAll()
    {
        var pointer = GetComponents<IPointerUpHandler>();
        if (pointer != null)
        {
            foreach (var item in pointer)
            {
                var poindHandler = item as MonoBehaviour;
                if (poindHandler != null)
                {
                    poindHandler.enabled = true;
                }
            }
        }
    }
}
