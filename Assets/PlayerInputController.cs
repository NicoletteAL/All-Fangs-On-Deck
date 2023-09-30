using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    creature creature;

    public Character_animation_switch sw;

    // Start is called before the first frame update
    void Awake()
    {
        creature = GetComponent<creature>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            creature.RandomizeColor();
        }

       /* if(Input.GetKeyDown(KeyCode.Q))
        { 
            sw.next_Animation_For_Prince("Prince_Throw");
            creature.LaunchProjectile();
            
        }
      */

        if(Input.GetKeyDown(KeyCode.Space))
        {
            creature.Jump();
        }

    }

    

    /// // Update is called once per frame
    void FixedUpdate()
    {
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
        //if(Input.GetKey(KeyCode.Space))
        //{
            //creature.Jump();
        //}
    }
}

//reference for sprite flip: https://www.youtube.com/watch?v=Cr-j7EoM8bg