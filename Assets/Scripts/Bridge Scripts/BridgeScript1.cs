using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript1 : MonoBehaviour
{
    public static BridgeScript1 instance;

    [SerializeField]
    private float forceY;

    private float tresholdY = 0.78957f;

    private float bridgeMaxScaleY = 0.9f;

    private float bridgeRotationAngle = -90;

    Transform doIt;

    private bool startBuild;

    private Vector3 rotationVector;

    void Awake()
    {
        MakeInstance();
        Initialize();
    }

    void Initialize()
    {
        doIt = GetComponent<Transform>();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        StartBuild();
    }

    void StartBuild()
    {
        if(startBuild)
        {
            if(transform.localScale.y >= bridgeMaxScaleY)
            {
                GameSoundManager.PlaySound("StopSound");
            }
            if (transform.localScale.y <= bridgeMaxScaleY)
            {
                GameSoundManager.PlaySound("BuildBridge");
                forceY += tresholdY * Time.deltaTime;
                doIt.transform.localScale = new Vector2(doIt.transform.localScale.x, forceY);
            }
        }
    }

    public void BuildBridge(bool startBuild)
    {
        this.startBuild = startBuild;
        if(!startBuild)
        {
            GameSoundManager.PlaySound("StopSound");
            rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = bridgeRotationAngle;
            transform.rotation = Quaternion.Euler(rotationVector);
            forceY = 0f;
            StopRun();
            if(RunScript1.instance != null)
            {
                RunScript1.instance.StopAll();
            }
        }
    }

    void StopRun()
    {
        if (PlayerScript1.instance != null)
        {
            PlayerScript1.instance.setPower = true;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "ExtraPointTag")
    //    {
    //        Debug.Log("first");
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "ExtraPointTag")
    //    {
    //        Debug.Log("second");
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "ExtraPointTag")
    //    {
    //        Debug.Log("third");
    //    }
    //}
}

