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
            sw.next_Animation_For_Prince("Jump_Arms");
            sw.next_Animation_For_Prince("Jump_Legs");

            rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Melee");
            Player.instance.Punch();

        }
        if (Input.GetKeyDown(KeyCode.K) || Input.GetMouseButtonDown(1))
        {
            Debug.Log("shoot");
            sw.next_Animation_For_Prince("Throw_Arms");
           
            Player.instance.LaunchProjectile();
            //garlicThrow();
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
            sw.next_Animation_For_Prince("Run_Legs");
            Flip(pos.x > 0);
        }
        else 
        {
            sw.next_Animation_For_Prince("Idle_Arms");
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
    
    /*
    public void garlicThrow()
    {

        StartCoroutine(garlicThrowRoutine());

        IEnumerator garlicThrowRoutine()
        {
            yield return new WaitForSeconds(2f);

        }

    } */
}
