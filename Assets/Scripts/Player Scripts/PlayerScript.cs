using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public static PlayerScript instance;

    private bool setPower;

    Transform run;
    //private Rigidbody2D myBody;

    GameObject platform;
    GameObject bridge;

    void Awake()
    {
        MakeInstance();
        Initialize();
    }

    void Update()
    {
        if(setPower == true)
        {
            var position = run.position;
            position.x += Time.deltaTime;
            run.position = position;
        }
    }

    void Initialize()
    {
        //myBody = GetComponent<Rigidbody2D>();
        run = GetComponent<Transform>();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void SetPower(bool setPower)
    {
        this.setPower = setPower;

        if (setPower)
        {
            Jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlatformTag")
        {
            platform = collision.gameObject;
            //Debug.Log("5");
            //Debug.Log("Landed on Platform");

            ////
            //platform = GameObject.FindWithTag("PlatformTag");
            //var a = platform.transform.position.x;
            //Debug.Log(a);
            //

            //
            bridge = GameObject.FindWithTag("BridgeTag");
            bridge.transform.position = new Vector2(platform.transform.position.x + platform.transform.localScale.x, bridge.transform.position.y);
            //
            bridge.transform.localScale = new Vector2(0.07007502f, 0.005975496f);
            Vector3 aaa = bridge.transform.rotation.eulerAngles;
            aaa.z = 0;
            bridge.transform.rotation = Quaternion.Euler(aaa);
            //

            if(PlayerScript.instance != null)
            {
                Debug.Log("2");
                PlayerScript.instance.SetPower(false);
            }
        }
        if(collision.tag == "MiddlePlatformTag")
        {
            Debug.Log("Fall");
        }
    }

    void Jump()
    {
    }
}
