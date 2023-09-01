using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed = 5.0f;

    public GameObject target;

    Rigidbody2D rb;
    // Start is called before the first frame update

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,20);

    }
    void Start()
    {
        //transform.rotation = Quaternion.LookRotation(transform.forward, target.transform.position - transform.position);
        //GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(transform.forward, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        //rb.velocity = transform.up * speed;
    }

    public void LaunchProjectile(Vector3 position){
        transform.rotation = Quaternion.LookRotation(transform.forward, position - transform.position);
        rb.velocity = transform.up * speed;
    }
}
