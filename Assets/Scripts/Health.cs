using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int health;
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts; 

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < health ? fullHeart : emptyHeart;
            hearts[i].enabled = i < maxHealth;
        }    
    }

    public void GainHealth(int h)
    {
        health += h;
    }

    public void TakeDamage(int d)
    {
        Debug.Log(health);
        if (health <= 0)
        {
            Debug.Log("You died");
        } else {
            health -= d;
        }
    }

}
