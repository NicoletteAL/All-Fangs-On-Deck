using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public SpriteRenderer playerSprite;
    public Color damagedColor = new Color(1f, 0.5f, 0f, 1f);
    public Color defaultColor;
    public float colorDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;  
        defaultColor = playerSprite.color;   
    }

    public void GainHealth(int h)
    {
        if (currentHealth + h > 100) 
        {
            currentHealth = 100;
        } else {
            currentHealth += h;
        }
    }

    public void TakeDamage(int d)
    {

        if (currentHealth <= 0)
        {
            Debug.Log("You died");
            //LoseMenu.DeathScreen();
        } else {
            currentHealth -= d;
        }
        StartCoroutine(FlashColor(damagedColor));
    }

    public IEnumerator FlashColor(Color c)
    {
        playerSprite.color = c;
        yield return new WaitForSeconds(colorDelay);
        playerSprite.color = defaultColor;
    }
}
