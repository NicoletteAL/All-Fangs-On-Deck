using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : PlayerHealth
{
    public SpriteRenderer enemySprite;
    public Color damagedColor = new Color(1f, 0.5f, 0f, 1f);
    private Color defaultColor;
    private float colorDelay = 0.15f;

    void Start()
    {
        defaultColor = enemySprite.color;
    }

    // Start is called before the first frame update
    public override void GainHealth(int h) {}

    public override void TakeDamage(int d)
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            currentHealth -= d;
        }
        StartCoroutine(FlashColor());
    }

    private IEnumerator FlashColor()
    {
        enemySprite.color = damagedColor;
        yield return new WaitForSeconds(colorDelay);
        enemySprite.color = defaultColor;
    }
    
}
