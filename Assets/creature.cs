using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature : MonoBehaviour
{
    [Header("Config")]
    public int healthPoints = 3;
    public float speed = 6.0f;
    public float jumpForce = 35f;
    public string creatureName = "Lonk";

    [Header("Projectiles")]
    public GameObject projectile;

    [Header("refrences")]
    SpriteRenderer sr;
    Rigidbody2D rb;
    
    //Temp placeholders
    public int health;
    public int maxHealth = 3;

    void Awake()
    {
        Debug.Log("awake called");
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start called");
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("update called");
        //myTransform.position += new Vector3(1f,0f,0f) * Time.deltaTime;
        
    }

    public void Move(Vector3 direction)
    {
        //transform.position += direction * speed * Time.deltaTime;
        //rb.MovePosition(transform.position+(direction * speed * Time.fixedDeltaTime));
        rb.velocity = direction * speed; //if u want to push 
    }

    public void RandomizeColor()
    {
        sr.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
    }

    public void LaunchProjectile()
    {
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.GetComponent<projectile>().LaunchProjectile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void Jump()
    {
        // Add an upward force to the Rigidbody component
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

    //public void TakeDamage(int d) => health -= d;
    public void TakeDamage(int d) 
    {
        health -= d;
        if (health <= 0)
        {
            Debug.Log("You died");
            //TODO: You Died text overlay
        }
    }

    //If they pick up a heart or something
    public void GainHealth(int h)
    {
        if (health != maxHealth)
        {
            health += h;
        }
    }
}
