using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreLabel;
    public int currentScore;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 1" || scene.name == "Level 2")
        {
            scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
            updateScore(0);
        } else 
        {
            currentScore = 0;
            scoreLabel.text = "";
        }
    }

    public void updateScore(int score) 
    {
        currentScore += score;
        scoreLabel.text = "Score: " + currentScore.ToString();
    }
}
