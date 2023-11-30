using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static int coinValue = 10;
    private Text scoreText; // Reference to the text component in the canvas

    private AudioSource soundEffect;
    public GameObject gameController;
   
    // Start is called before the first frame update
    
    void Start()
    {
        gameController = GameObject.Find("GameController");
        
        GameObject coinAudioObj = GameObject.Find("CoinSound");
        if (coinAudioObj != null)
        {
            soundEffect = coinAudioObj.GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collision!");
        if (other.CompareTag("Player"))
        {
            gameController.GetComponent<ScoreManager>().updateScore(coinValue);
            Destroy(this.gameObject);
            PlaySoundEffect();
        }
    }
    
    void PlaySoundEffect()
    {
        soundEffect.Play(); // Play the sound effect
    }
}
