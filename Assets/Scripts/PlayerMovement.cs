using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //CharacterController controller;
    [Header("Movement")]
    public float speed = 3f;
    public float jumpAmount = 4f;

    Rigidbody2D rb2d;

    bool grounded = false;

    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        grounded = isGrounded();
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        } 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),0f) * Time.fixedDeltaTime * speed;   
    }

    bool isGrounded() {
        RaycastHit2D hit  = Physics2D.Raycast(rb2d.position, Vector2.down, 1f, groundLayer);
	
	    if (hit.collider != null) {
            return true;
	    }
        return false;
    }
    
}
