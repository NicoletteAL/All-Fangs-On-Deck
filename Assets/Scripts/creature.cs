using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature : MonoBehaviour
{
    [Header("Config")]
    public int health;
    public int maxHealth = 3;  //TODO: change to 100 and update HealthDisplay .. % 10
    public float speed = 6.0f;
    public float jumpForce = 35f;
    public string creatureName = "Lonk";
    private float DMG_DELAY = 1.5f;

    [Header("Projectiles")]
    public GameObject projectile;

    [Header("References")]
    SpriteRenderer sr;
    Rigidbody2D rb;
    
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

    /*Movement Functions*/
    public void Move(Vector3 direction)
    {
        //transform.position += direction * speed * Time.deltaTime;
        //rb.MovePosition(transform.position+(direction * speed * Time.fixedDeltaTime));
        rb.velocity = direction * speed; //if u want to push 
    }

    public void Jump()
    {
        // Add an upward force to the Rigidbody component
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

    public void RandomizeColor()
    {
        sr.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
    }

    public void LaunchProjectile()
    {
        //GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        //newProjectile.GetComponent<projectile>().LaunchProjectile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    /*Health Functions*/
    public void TakeDamage(int d) 
    {
        Debug.Log("took damage");
        if (health <= 0)
        {
            Debug.Log("You died");
            //TODO: You Died text overlay
        } else {
            health -= d;
        }
    }

    public void GainHealth(int h)
    {
        //play sound effect
        health += h;
    }

    /*Collisions / Triggers*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1); //temp
            StartCoroutine(DamageDelay());
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject collidedObject = collider.gameObject;

        if (collidedObject.tag != "Item")
            return;

        //switch statement if there are more items

        if (health != maxHealth)
        {
            GainHealth(1); //temp value
            Destroy(collider.gameObject);
        }
    }

    IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(DMG_DELAY);
    }
}
