using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature : MonoBehaviour
{
    [Header("Config")]
    public int health;
    public int maxHealth = 3;  
    public float speed = 6.0f;
    public float jumpForce = 35f;
    public string creatureName = "Lonk";

    /*[Header("Projectiles")]
    public GameObject projectile;
    public GameObject shootSpawn;*/

    //[Header("References")]
    //Rigidbody2D rb;
    
    void Awake()
    {
        //Debug.Log("awake called");
        //rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start called");
        //Debug.Log("start called");
       // health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("update called");
        //myTransform.position += new Vector3(1f,0f,0f) * Time.deltaTime;
        
    }

    /*Movement Functions*/
    /*public void Move(Vector3 direction)
    {
        //transform.position += direction * speed * Time.deltaTime;
        //rb.MovePosition(transform.position+(direction * speed * Time.fixedDeltaTime));
        rb.velocity = direction * speed; //if u want to push 
    }*/

    /*public void Jump()
    {
        // Add an upward force to the Rigidbody component
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }*/

    /*public void LaunchProjectile()
    {
        Instantiate(projectile, new Vector3(shootSpawn.transform.position.x, shootSpawn.transform.position.y, 0f), Quaternion.identity);
    }*/

}
