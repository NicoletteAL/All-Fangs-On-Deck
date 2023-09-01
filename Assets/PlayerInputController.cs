using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    creature creature;
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

        if(Input.GetKeyDown(KeyCode.Q))
        {
            creature.LaunchProjectile();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            creature.Jump();
        }

    }

    

    /// // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            creature.Move(new Vector3(1,0,0));
        } else if(Input.GetKey(KeyCode.A))
        {
            creature.Move(new Vector3(-1,0,0));
        } 
        //if(Input.GetKey(KeyCode.Space))
        //{
            //creature.Jump();
        //}
    }
}
