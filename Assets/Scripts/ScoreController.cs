using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {
    int score = 0;

    public int GetScore()
    {
        return score;
    }
    public void IncrementScore()
    {
        score++;
    }
}
