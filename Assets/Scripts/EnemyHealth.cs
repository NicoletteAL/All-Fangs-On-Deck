using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public SpriteRenderer enemySprite;
    public Color damagedC = new Color(1f, 0.5f, 0f, 1f);
    public Color defaultC;
    public float delay = 0.15f;

    public AudioSource enemyDeath;
    public AudioSource enemyDamaged;

    public GameObject gameController;
    public int enemyScoreValue = 100;

    void Start()
    {
        defaultC = enemySprite.color;
        gameController = GameObject.Find("GameController");
    }

    public void TakeDamage(int d)
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
        enemySprite.color = damagedC;
        yield return new WaitForSeconds(delay);
        enemySprite.color = defaultC;
    }
    
}
