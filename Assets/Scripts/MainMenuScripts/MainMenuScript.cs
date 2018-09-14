using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    #region Public methods
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
    #endregion
}
