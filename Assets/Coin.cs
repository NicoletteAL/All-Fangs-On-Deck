using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static int score = 0;
    private Text scoreText; // Reference to the text component in the canvas

    private AudioSource soundEffect;

    
    // Start is called before the first frame update
    
    private void Start()
    {
        // Find the UI legacy text object with the name "CoinScore"
        GameObject coinScoreObj = GameObject.Find("CoinScore");
        if (coinScoreObj != null)
        {
            scoreText = coinScoreObj.GetComponent<Text>();
        }
        
        // Find the game object with the name "CoinAudio"
        GameObject coinAudioObj = GameObject.Find("CoinSound");
        if (coinAudioObj != null)
        {
            soundEffect = coinAudioObj.GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision!");
        if(other.GetComponent<creature>() != null)
        {
            Destroy(this.gameObject);
            IncrementScore();
            PlaySoundEffect();
            
        }

    }
    void IncrementScore()
    {
        score++; // Increment the score value by 1
        scoreText.text = score.ToString(); // Update the text component with the new score value
    }

    void PlaySoundEffect()
    {
        soundEffect.Play(); // Play the sound effect
    }
}
