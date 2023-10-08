using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int currentHealth;
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts; 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < (currentHealth / 10) ? fullHeart : emptyHeart;
            hearts[i].enabled = i < maxHealth;
        }    
    }

    public virtual void GainHealth(int h)
    {
        currentHealth += h;
    }

    public void TakeDamage(int d)
    {
        if (currentHealth <= 0)
        {
            Debug.Log("You died");
        } else {
            currentHealth -= d;
        }
    }

}
