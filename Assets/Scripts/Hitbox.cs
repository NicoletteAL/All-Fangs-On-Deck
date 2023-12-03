using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int dmg = 5;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") { // damage enemy
            Debug.Log("hit!");
            if(col.gameObject.GetComponent<EnemyHealth>() != null) {
                GetComponent<AudioSource>().pitch = Random.Range(.7f,1.2f);
                GetComponent<AudioSource>().Play();
                col.gameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
            }
        }
    }

    public void setDir(bool flip) { // invert bool, so right = 1->0
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = !flip;
    }
}
