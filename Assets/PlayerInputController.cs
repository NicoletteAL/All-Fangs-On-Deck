using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    [Header("Movement")]
    public float speed = 3f;
    public float jumpAmount = 4f;

    Rigidbody2D rb2d;
    bool grounded = false;
    public LayerMask groundLayer;

    Player instance;

    public Character_animation_switch sw;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        grounded = isGrounded();
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            Debug.Log("Melee");
            Player.instance.Punch();
            
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            Debug.Log("shoot");
            Player.instance.LaunchProjectile();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),0f) * Time.fixedDeltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            sw.next_Animation_For_Prince("Prince_Throw");
            creature.LaunchProjectile();

        }

        if (Input.GetKey(KeyCode.D))
        {
            creature.Move(new Vector3(1,0,0));
            creature.transform.localScale = new Vector3(2, 2, 1);
            sw.next_Animation_For_Prince("Prince_Run"); 
            

        } else if(Input.GetKey(KeyCode.A))
        {
            creature.Move(new Vector3(-1,0,0));
            creature.transform.localScale = new Vector3(-2, 2, 1);
            sw.next_Animation_For_Prince("Prince_Run");

        }
        else
        {
            sw.next_Animation_For_Prince("Standing_There");
        }
    }

    bool isGrounded() {
        RawcastHit2D hit = Physics2D.Raycast(rb2d.position, Vector2.down, 1f, groundLayer);

        if (hit.collider != null) {
            return true;
        }
        return false;
    }
}

//reference for sprite flip: https://www.youtube.com/watch?v=Cr-j7EoM8bg