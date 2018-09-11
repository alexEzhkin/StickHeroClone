using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if(BridgeScript.instance != null)
        {
            BridgeScript.instance.SePower(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (BridgeScript.instance != null)
        {
            BridgeScript.instance.SePower(false);
            //if(PlayerScript.instance != null)
            //{
            //    PlayerScript.instance.SetPower(false);
            //}
        }
    }
}
