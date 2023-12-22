using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public event Action<int> onScoreAdd;
    public event Action<int> onGameOver;

    private int score = 0;

    public void AddScore()
    {
        score++;
        onScoreAdd?.Invoke(score);
    }

    public void ShowFinalScore()
    {
        onGameOver?.Invoke(score);
    }

    public int GetScore { get { return score; } }

}
