using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region Fields
    public static RunScript instance;
    #endregion

    #region Unity lifecycle
    void Awake()
    {
        MakeInstance();
    }
    #endregion

    #region Event handlers
    public void OnPointerDown(PointerEventData eventData)
    {
        if (BridgeScript.instance != null)
        {
            BridgeScript.instance.BuildBridge(true);
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if (BridgeScript.instance != null)
        {
            BridgeScript.instance.BuildBridge(false);
        }
    }
    #endregion

    #region Public methods
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
    #endregion

    #region Private methods
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
}
