using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb2d;
    public int dmg = 10;
    public bool right; // 0 = left, 1 = right

    public Projectile(bool r) {
        right = r;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
        if(right) {
            rb2d.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
        }
        else {
            rb2d.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible(){
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") { // damage enemy
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
            Destroy(this.gameObject);
        }
    }

    public void setDir(bool leftRight){
        right = leftRight;
    }
}
