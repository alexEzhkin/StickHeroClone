using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoreManager
{

    #region Properties
    public static int HighScore { get; private set; }
    #endregion

    #region Public methods
    public static void UpdateHighScore(int value)
    {
        HighScore = value;
    }
    #endregion
}
