using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    #region Fields
    public static BridgeScript instance;


    [SerializeField]
    private float forceY;


    private float tresholdY = 0.78957f;
    private float bridgeMaxScaleY = 0.9f;
    private float bridgeRotationAngle = -90;
    private bool hasBuild;
    Transform bridge;
    Vector3 rotationVector;
    #endregion

    #region Unity lifecycle
    void Awake()
    {
        MakeInstance();
        Initialize();
    }


    void Update()
    {
        StartBuild();
    }
    #endregion

    #region Public methods
    public void BuildBridge(bool hasBuild)
    {
        this.hasBuild = hasBuild;
        if (!hasBuild)
        {
            GameSoundManager.PlaySound("StopSound");
            rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = bridgeRotationAngle;
            transform.rotation = Quaternion.Euler(rotationVector);
            forceY = 0f;
            StartRun();

            if (RunScript.instance != null)
            {
                RunScript.instance.StopAll();
            }
        }
    }
    #endregion

    #region Private methods
    void Initialize()
    {
        bridge = GetComponent<Transform>();
    }


    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void StartBuild()
    {
        if (hasBuild)
        {
            if (transform.localScale.y >= bridgeMaxScaleY)
            {
                GameSoundManager.PlaySound("StopSound");
            }
            if (transform.localScale.y <= bridgeMaxScaleY)
            {
                GameSoundManager.PlaySound("BuildBridge");
                forceY += tresholdY * Time.deltaTime;
                bridge.transform.localScale = new Vector2(bridge.transform.localScale.x, forceY);
            }
        }
    }


    void StartRun()
    {
        if (PlayerScript.instance != null)
        {
            PlayerScript.instance.isRun = true;
        }
    }
    #endregion
}
