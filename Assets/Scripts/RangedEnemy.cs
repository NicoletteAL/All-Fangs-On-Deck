using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{    
    public override void Start()
    {
        currentState = State.Idle;
    }

    public override void FixedUpdate()
    {
        switch (currentState)
        {
            default:
            case State.Idle:
                Idle();
                break;
            case State.Attack:
                Attack();
                break;
        }
    }

    public override void Move() 
    {
        //be triggered by ontriggerenter
        //move towards player but stop a few feet/pixels/whatver away from the player
        //change state to attack
    }

    public override void Attack()
    {
        //base.Attack();
        //shoot projectiles
        //projectile damage player on collision
        Debug.Log("attacking");

    }

    public void Idle()
    {
        Debug.Log("hi");
        //stop shooting
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            moveSpeed = DEFAULT_MSPEED;
            Move();
        }
    }



}
