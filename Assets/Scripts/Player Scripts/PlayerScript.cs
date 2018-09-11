using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public static PlayerScript instance;

    private bool setPower;

    Transform run;
    private Rigidbody2D myBody;

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
        myBody = GetComponent<Rigidbody2D>();
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
            Debug.Log("5");
            Debug.Log("Landed on Platform");
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
