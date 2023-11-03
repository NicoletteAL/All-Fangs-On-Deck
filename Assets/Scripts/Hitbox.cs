using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int dmg = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) {
        //TODO: Check if enemy was hit
        //Debug.Log(col.gameObject);
        if (col.gameObject.tag == "Enemy") { // damage enemy
            Debug.Log("hit!");
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
        }
        
    }
}
