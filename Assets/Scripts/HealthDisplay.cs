using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts; 
    public GameObject MusicOne;
   

    public LoseMenu loss;
    
    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        for(int i = 0; i < hearts.Length; i++)
        {
            if (playerHealth.currentHealth <= 0) 
            {
                hearts[i].enabled = false;
                Destroy(MusicOne);
                
                loss.DeathScreen();
                


            } 
            else
            {
                hearts[i].sprite = i < (playerHealth.currentHealth / 10) ? fullHeart : emptyHeart;
                hearts[i].enabled = i < playerHealth.maxHealth;
            }
        }    
    }
    
}
