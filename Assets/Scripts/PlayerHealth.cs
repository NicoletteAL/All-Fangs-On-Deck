using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public LoseMenu loss;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;    
    }

    public virtual void GainHealth(int h)
    {
        currentHealth = (currentHealth + h > 100) ? 100 : currentHealth + h;
    }

    public virtual void TakeDamage(int d)
    {
        if (currentHealth <= 0)
        {
            Debug.Log("You died");
            loss.DeathScreen();
        } else {
            currentHealth -= d;
        }
    }
}
