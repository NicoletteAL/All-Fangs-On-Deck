using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb2d;
    public int dmg = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
        rb2d.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Enemy") { // damage enemy
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
        }
        Destroy(this.gameObject);
    }
}
