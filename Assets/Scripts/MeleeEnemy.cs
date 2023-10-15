using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = Player.instance.GetComponent<PlayerHealth>();
    }
    
    void Start()
    {
        currentState = State.Follow;
    }

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

    public override void Attack()
    {
        Debug.Log("Melee Attacking");
        moveSpeed = 0.0f;
        base.Attack();
    }
   
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            currentState = State.Attack;
        }
    }
    

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            currentState = State.Attack;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        moveSpeed = DEFAULT_MSPEED;
        currentState = State.Follow;
    }

}
