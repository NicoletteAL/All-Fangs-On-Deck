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
    public Animator princeAnimate;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        grounded = isGrounded();
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            sw.next_Animation_For_Prince("Jump_Arms");
            //princeAnimate.SetBool("Jump", true);
            sw.next_Animation_For_Prince("Jump_Legs");

            rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if(isGrounded())
        {
            princeAnimate.SetBool("Jump",false);
        }
        else
        {
            princeAnimate.SetBool("Jump",true);
        }

        if (Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0))
        {
            Player.instance.Punch();
            princeAnimate.SetTrigger("Attack");

        }
        if (Input.GetKeyUp(KeyCode.J) || Input.GetMouseButtonDown(0))
        {
            //princeAnimate.SetTrigger("Attack", false);
        }

        if (Input.GetKeyDown(KeyCode.K) || Input.GetMouseButtonDown(1))
        {
            sw.next_Animation_For_Prince("Throw_Arms");
            princeAnimate.SetTrigger("Range");
            Player.instance.LaunchProjectile();
        }

        if (Input.GetKeyUp(KeyCode.K) || Input.GetMouseButtonDown(1))
        {
            //princeAnimate.SetTrigger("Range", false);
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
            sw.next_Animation_For_Prince("Run_Arms");
            princeAnimate.SetBool("Run", true);
            sw.next_Animation_For_Prince("Run_Legs");
            
            Flip(pos.x > 0);
        }
        else 
        {
            sw.next_Animation_For_Prince("Idle_Arms");
            princeAnimate.SetBool("Run", false);
            sw.next_Animation_For_Prince("Idle_Legs");
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
