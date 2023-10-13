using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    void FixedUpdate()
    {
        switch (currentState)
        {
            default:
            case State.Attack:
                Attack();
                break;
            case State.Follow:
                Move();
                break;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            moveSpeed = 0.0f;
            currentState = State.Attack;
        }
    }

}
