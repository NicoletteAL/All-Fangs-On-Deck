using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText; // Reference to the UI Text component to display the score

    void Update()
    {
        if (scoreText != null)
        {
            // Access the score from the Coin script directly
            int currentScore = Coin.score; // Access the static 'score' variable from the Coin script

            // Update the UI text with the current score value
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}
