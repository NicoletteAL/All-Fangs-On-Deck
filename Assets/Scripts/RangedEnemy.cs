using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{    
    [Header("Ranged Config")]
    [SerializeField]
    private float targetDistance;
    private float distanceBetweenPlayer;

    public override void Start()
    {
        currentState = State.Idle;
    }

    public override void FixedUpdate()
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
            case State.Idle:
                Idle();
                break;
            case State.Run:
                Move();
                break;
        }
    }

    public override void Move() 
    {
       moveSpeed = DEFAULT_MSPEED;
       base.Move();

    }

    public override void Attack()
    {
        Debug.Log("attacking");
        moveSpeed = 0.0f;
        base.Attack();
    }

    public void Idle()
    {
        Debug.Log("hi");
        moveSpeed = 0.0f;
        //stop shooting
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            moveSpeed = DEFAULT_MSPEED;
            currentState = State.Follow;
            Debug.Log("Following");
        }
    }

    public override void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            distanceBetweenPlayer = Mathf.Abs(transform.position.x - player.transform.position.x);
            if (distanceBetweenPlayer <= attackRange && distanceBetweenPlayer >= targetDistance)
            {
                currentState = State.Attack;
                Debug.Log("In attack range");
            }
            else if (distanceBetweenPlayer <= targetDistance)
            {
                currentState = State.Run; //Needs to run in opposite direction of the player? idk
                Debug.Log("Running");
            }
            else 
            {
                currentState = State.Follow;
                Debug.Log("Following + not in attack range");
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D col)
    {
        moveSpeed = DEFAULT_MSPEED;
        currentState = State.Follow;
    }

    //yellow shows trigger range, red shows target distance
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetDistance);
    }



}