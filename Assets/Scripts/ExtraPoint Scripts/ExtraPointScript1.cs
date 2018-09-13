using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPointScript1 : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BridgeTag")
        {
            Debug.Log("first");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "BridgeTag")
        {
            Debug.Log("second");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BridgeTag")
        {
            Debug.Log("third");
        }
    }
}
