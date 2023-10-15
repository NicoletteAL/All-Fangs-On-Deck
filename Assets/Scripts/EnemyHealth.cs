using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : PlayerHealth
{
    // Start is called before the first frame update
    public override void GainHealth(int h) {}

    public override void TakeDamage(int d)
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy Dead");
            Destroy(gameObject);
        }
        else
        {
            currentHealth -= d;
        }
    }
    
}
