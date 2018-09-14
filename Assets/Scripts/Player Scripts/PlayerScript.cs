using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region Fields
    public static PlayerScript instance;


    private float bridgeScaleX = 0.07007502f;
    private float bridgeScaleY = 0.005975496f;
    GameObject platform;
    GameObject bridge;
    Transform runPlayer;

    public bool isRun;
    #endregion

    #region Unity lifecycle
    void Awake()
    {
        MakeInstance();
        Initialize();
    }


    void Update()
    {
        if (isRun == true)
        {
            GameSoundManager.PlaySound("Run");
            var position = runPlayer.position;
            position.x += Time.deltaTime;
            runPlayer.position = position;
        }
    }
    #endregion

    #region Event handlers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlatformTag")
        {
            GameSoundManager.PlaySound("StopSound");
            GameSoundManager.PlaySound("Point");

            platform = collision.gameObject;

            bridge = GameObject.FindWithTag("BridgeTag");
            bridge.transform.position = new Vector2(platform.transform.position.x + platform.transform.localScale.x, bridge.transform.position.y);

            bridge.transform.localScale = new Vector2(bridgeScaleX, bridgeScaleY);
            Vector3 bridgeRotationAngles = bridge.transform.rotation.eulerAngles;
            bridgeRotationAngles.z = 0;
            bridge.transform.rotation = Quaternion.Euler(bridgeRotationAngles);

            isRun = false;

            runPlayer.position = new Vector2(platform.transform.position.x, runPlayer.transform.position.y);

            if (RunScript.instance != null)
            {
                RunScript.instance.StartAll();
            }

            if (GameManager.instance != null)
            {
                GameManager.instance.CreateNewPlatformAndLerp(collision.transform.position.x);
            }

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.IncrementScore();
            }
        }

        if (collision.tag == "MiddlePlatformTag")
        {
            isRun = false;
            GameSoundManager.PlaySound("StopSound");
            GameSoundManager.PlaySound("Death");

            if (GameOverManager.instance != null)
            {
                GameOverManager.instance.GameOverPanelShow();
            }
        }
    }
    #endregion

    #region Private methods
    void Initialize()
    {
        runPlayer = GetComponent<Transform>();
    }


    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
}
