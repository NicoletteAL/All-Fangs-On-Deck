using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreLabel;
    public int currentScore;

    public void updateScore(int score) 
    {
        currentScore += score;
        scoreLabel.text = "Score: " + currentScore.ToString();
    }
}
