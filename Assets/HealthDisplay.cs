using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    /* replace with player object */
    //public PlayerStatsHandler playerStatsHandler;

    void Start()
    {
        //get player's healt and set it to health
        health = maxHealth;
    }
    
    void Update()
    {
        //health = playerStatsHandler.health;
        //maxHealth = playerStatsHandler.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < health ? fullHeart : emptyHeart;
            hearts[i].enabled = i < maxHealth;
        }
    }

    /*
        Temp functions to test health system
            Red - TakeDamage()
            Green - GainHealth()
    */
    public void TakeDamage(int d)
    {
        if (health != 0)
        {
            health -= d;
        }
        Debug.Log(health);
    }

    public void GainHealth(int h)
    {
        if (health != maxHealth)
        {
            health += h;
        }
    }
}