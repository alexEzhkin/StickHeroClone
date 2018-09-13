using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public void PlayGame()
    {
        Application.LoadLevel("Gameplay");
    }

    public void SoundOff()
    {
        GameSoundManager.MuteSound();
    }

    public void SoundOn()
    {
        GameSoundManager.ActiveSound();
    }
}
