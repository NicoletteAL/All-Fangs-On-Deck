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

    public SpriteRenderer sr;
    public Character_animation_switch sw;

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
        Vector3 pos = new Vector3(Input.GetAxisRaw("Horizontal"), 0f);
        transform.position += pos * Time.fixedDeltaTime * speed;

        if (pos.x != 0)
        {
            //animation run
            sw.next_Animation_For_Prince("Prince_Run");
            Flip(pos.x > 0);
        }
        else 
        {
            sw.next_Animation_For_Prince("Standing_There");
        }
    }

    bool isGrounded() {
        RaycastHit2D hit  = Physics2D.Raycast(rb2d.position, Vector2.down, 1.5f, groundLayer);
	
	    if (hit.collider != null) {
            return true;
	    }
        return false;
    }

    private void Flip(bool b)
    {
        sr.flipX = b;
    }
    
}
