﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript1 : MonoBehaviour
{
    public static BridgeScript1 instance;

    [SerializeField]
    private float forceY;

    private float tresholdY = 0.78957f;

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
            if (transform.localScale.y <= 0.9f)
            {
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
            rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = -90;
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
}

