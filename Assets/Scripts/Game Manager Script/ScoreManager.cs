using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    #region Fields
    public static ScoreManager instance;


    private Text scoreText;
    private int score;
    #endregion

    #region Unity lifecycle
    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        MakeInstance();
    }
    #endregion

    #region Public methods
    public void IncrementScore()
    {
        score++;
        scoreText.text = "" + score;
    }


    public int GetScore()
    {
        return this.score;
    }
    #endregion

    #region Private methods
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
}
