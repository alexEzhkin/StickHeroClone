using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoreManager{

    public static int HighScore { get; private set; }

    public static void UpdateHighScore(int value)
    {
        HighScore = value;
    }
}
