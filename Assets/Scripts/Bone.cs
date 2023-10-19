using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public int dmg = 10;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (Player.instance.transform.position - transform.position).normalized;
        transform.GetComponent<Rigidbody2D>().velocity = direction * 2.0f;
        transform.Rotate(Vector3.forward * 500.0f * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(dmg);
            Destroy(gameObject);
        }
        Destroy(gameObject, 5.0f);
    }
}
