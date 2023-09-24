using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    /* replace with player object */
    public creature c;

    void Start()
    {
        //get player's healt and set it to health
        health = c.health;
    }
    
    void Update()
    {
        health = c.health;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < health ? fullHeart : emptyHeart;
            hearts[i].enabled = i < c.maxHealth;
        }
    }

}