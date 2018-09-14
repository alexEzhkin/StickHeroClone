using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    #region Fields
    public static GameOverManager instance;


    private GameObject gameOverPanel;
    private GameObject scoreText;
    private Animator gameOverAnimation;
    private Button restartButton, backButton;
    private Text finalScore;
    private Text bestScore;
    private int currentScore;
    #endregion

    #region Unity lifecycle
    void Awake()
    {
        MakeInstance();
        InitializeVariables();
    }
    #endregion

    #region Public methods
    public void GameOverPanelShow()
    {
        scoreText.SetActive(false);
        gameOverPanel.SetActive(true);

        currentScore = ScoreManager.instance.GetScore();

        if (currentScore >= HighScoreManager.HighScore)
        {
            HighScoreManager.UpdateHighScore(currentScore);
        }

        finalScore.text = "Score\n" + "" + ScoreManager.instance.GetScore();

        bestScore.text = "Best Score\n" + "" + HighScoreManager.HighScore;

        gameOverAnimation.Play("FadeIn");
    }


    public void PlayAgain()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }


    public void BackToMenu()
    {
        Application.LoadLevel("MainMenu");
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


    void InitializeVariables()
    {
        gameOverPanel = GameObject.Find("GameOverPanelHolder");
        gameOverAnimation = gameOverPanel.GetComponent<Animator>();

        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        backButton = GameObject.Find("BackButton").GetComponent<Button>();

        restartButton.onClick.AddListener(() => PlayAgain());
        backButton.onClick.AddListener(() => BackToMenu());

        scoreText = GameObject.Find("ScoreText");
        finalScore = GameObject.Find("GameOverScore").GetComponent<Text>();
        bestScore = GameObject.Find("BestScore").GetComponent<Text>();


        gameOverPanel.SetActive(false);
    }
    #endregion
}
