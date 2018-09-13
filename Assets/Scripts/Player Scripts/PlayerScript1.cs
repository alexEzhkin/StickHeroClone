using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript1 : MonoBehaviour
{
    public static PlayerScript1 instance;

    public bool setPower;

    Transform run;

    GameObject platform;
    GameObject bridge;

    void Awake()
    {
        MakeInstance();
        Initialize();
    }

    void Update()
    {
        if (setPower == true)
        {
            GameSoundManager.PlaySound("Run");
            var position = run.position;
            position.x += Time.deltaTime;
            run.position = position;
        }
    }

    void Initialize()
    {
        run = GetComponent<Transform>();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlatformTag")
        {
            GameSoundManager.PlaySound("StopSound");
            platform = collision.gameObject;

            bridge = GameObject.FindWithTag("BridgeTag");
            bridge.transform.position = new Vector2(platform.transform.position.x + platform.transform.localScale.x, bridge.transform.position.y);

            bridge.transform.localScale = new Vector2(0.07007502f, 0.005975496f);
            Vector3 aaa = bridge.transform.rotation.eulerAngles;
            aaa.z = 0;
            bridge.transform.rotation = Quaternion.Euler(aaa);

            setPower = false;

            run.position = new Vector2(platform.transform.position.x, run.transform.position.y);

            if(RunScript1.instance != null)
            {
                RunScript1.instance.StartAll();
            }

            if (GameManager.instance != null)
            {
                Debug.Log("Landed on platform after jumping");
                GameManager.instance.CreateNewPlatformAndLerp(collision.transform.position.x);
            }

            if(ScoreManager.instance != null)
            {
                ScoreManager.instance.IncrementScore();
            }
        }

        if (collision.tag == "MiddlePlatformTag")
        {
            GameSoundManager.PlaySound("StopSound");
            setPower = false;
            GameSoundManager.PlaySound("Death");
            Debug.Log("Fall");
            if(GameOverManager.instance != null)
            {
                GameOverManager.instance.GameOverPanelShow();
            }
        }
    }
}
