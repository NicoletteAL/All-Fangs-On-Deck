using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    Rigidbody2D rb2d;

    Player instance;

    public Character_animation_switch sw;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0)) {
            Player.instance.Punch();
            
        }
        if (Input.GetKeyDown(KeyCode.K) || Input.GetMouseButtonDown(1)) {
            //sw.next_Animation_For_Prince("Prince_Throw");
            Player.instance.LaunchProjectile();
        } */
    }
}

//reference for sprite flip: https://www.youtube.com/watch?v=Cr-j7EoM8bg