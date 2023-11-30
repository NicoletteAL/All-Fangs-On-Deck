using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : PlayerHealth
{
    public SpriteRenderer enemySprite;
    public Color damagedColor = new Color(1f, 0.5f, 0f, 1f);
    private Color defaultColor;
    private float colorDelay = 0.15f;

    public AudioSource enemyDeath;
    public AudioSource enemyDamaged;

    public GameObject gameController;
    public int enemyScoreValue = 100;

    void Start()
    {
        defaultColor = enemySprite.color;
        gameController = GameObject.Find("GameController");
    }

    // Start is called before the first frame update
    public override void GainHealth(int h) {}

    public override void TakeDamage(int d)
    {
        if (currentHealth <= 0)
        {
            if(enemyDeath != null) {
                enemyDeath.pitch = Random.Range(1.1f,1.2f);
                enemyDeath.Play();
            }
            transform.position = new Vector3(100000,0,0);
            gameController.GetComponent<ScoreManager>().updateScore(enemyScoreValue);
            Destroy(gameObject,5.0f);
        }
        else
        {
            if(enemyDamaged != null) {
                enemyDamaged.pitch = Random.Range(1.1f,1.2f);
                enemyDamaged.Play();
            }
            
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
