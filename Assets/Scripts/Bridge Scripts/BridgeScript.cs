using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour {

    public static BridgeScript instance;

    [SerializeField]
    private float forceY;

    private float tresholdY = 0.78957f;

    Transform doIt;
    //BoxCollider2D aaa;
    //Rigidbody2D rigid;

    private bool sePower;

    public Vector3 rotationVector;

    void Awake()
    {
        MakeInstance();
        Initialize();
    }

    void Initialize()
    {
        doIt = GetComponent<Transform>();
        //aaa = GetComponent<BoxCollider2D>();
        //rigid = GetComponent<Rigidbody2D>();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        SePower();
        if (rotationVector.z == -90f)
        {
            sePower = false;
        }
    }

    void SePower()
    {
        if (sePower)
        {
            if (transform.localScale.y <= 0.9f)
                forceY += tresholdY * Time.deltaTime;
                doIt.transform.localScale = new Vector2(doIt.transform.localScale.x, forceY);
        }
    }

    public void SePower(bool sePower)
    {
        this.sePower = sePower;
        if (!sePower)
        {
            Change();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlatformTag")
        {
            sePower = false;
        }
    }

    void Change()
    {
        Debug.Log("We have released button");

        rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = -90;
        transform.rotation = Quaternion.Euler(rotationVector);
        forceY = 0f;
        StopRun();
    }

    void StopRun()
    {
            if (PlayerScript.instance != null)
            {
                PlayerScript.instance.SetPower(true);
            }
    }



}
