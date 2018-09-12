using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private GameObject middlePlatform;

    private float minX = -2.5f, maxX = 2.5f;

    private bool lerpCamera;
    private float lerpTime = 1.5f;
    private float lerpX;

    void Awake()
    {
        MakeInstance();
    }

    void Update()
    {
        if (lerpCamera)
        {
            LerpTheCamera();
        }
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void LerpTheCamera()
    {
        float x = Camera.main.transform.position.x;

        x = Mathf.Lerp(x, lerpX, lerpTime * Time.deltaTime);
        Camera.main.transform.position = new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z);

        if (Camera.main.transform.position.x >= (lerpX - 0.07f))
        {
            lerpCamera = false;
            middlePlatform = GameObject.FindWithTag("MiddlePlatformTag");
            middlePlatform.transform.position = new Vector2(Camera.main.transform.position.x, middlePlatform.transform.position.y);
            //Instantiate(middlePlatform, new Vector2(Camera.main.transform.position.x, middlePlatform.transform.position.y),Quaternion.identity);
        }
    }

    public void CreateNewPlatformAndLerp(float lerpPosition)
    {
        CreateNewPlatform();

        lerpX = lerpPosition + maxX;
        lerpCamera = true;
    }

    void CreateNewPlatform()
    {
        float cameraX = Camera.main.transform.position.x;

        float newMaxX = (maxX * 2) + cameraX;

        Instantiate(platform, new Vector3(Random.Range(newMaxX, newMaxX - 1.2f), platform.transform.position.y, 0), Quaternion.identity);
    }
}
