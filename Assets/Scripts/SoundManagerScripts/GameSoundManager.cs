using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    #region Fields
    public static AudioClip buildBridgeSound, runSound, deathSound, pointSound;
    static AudioSource audioSrc;
    #endregion

    #region Unity lifecycle
    void Start()
    {
        buildBridgeSound = Resources.Load<AudioClip>("BuildBridge");
        runSound = Resources.Load<AudioClip>("Run");
        deathSound = Resources.Load<AudioClip>("Death");
        pointSound = Resources.Load<AudioClip>("Point");

        audioSrc = GetComponent<AudioSource>();
    }
    #endregion

    #region Public methods
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "BuildBridge":
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(buildBridgeSound);
                }
                break;
            case "Run":
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(runSound);
                }
                break;
            case "Death":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "Point":
                audioSrc.PlayOneShot(pointSound);
                break;
            case "StopSound":
                audioSrc.Stop();
                break;
        }
    }


    public static void MuteSound()
    {
        AudioListener.volume = 0;
    }


    public static void ActiveSound()
    {
        AudioListener.volume = 1;
    }
    #endregion
}
