using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public int dmg = 10;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") { // damage enemy
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(dmg);
        }
    }
}
