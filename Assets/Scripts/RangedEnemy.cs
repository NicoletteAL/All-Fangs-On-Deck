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
                Move(-1);
                break;
            case State.Idle:
                Idle();
                break;
            case State.Run:
                Move(1);
                break;
        }
    }

    public void Move(int flipVal) 
    {
        //move towards player but stop a few feet/pixels/whatver away from the player
        moveSpeed = DEFAULT_MSPEED;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (flipVal * -1);
        transform.Translate(moveSpeed * Time.deltaTime * flipVal, 0,0);
        transform.localScale = scale;
    }

    public override void Attack()
    {
        //base.Attack();
        //shoot projectiles
        //projectile damage player on collision
        Debug.Log("attacking");
        moveSpeed = 0.0f;
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
            currentState = State.Follow;
        }
    }

    public override void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            distanceBetweenPlayer = transform.position.x - player.transform.position.x;
            if (distanceBetweenPlayer >= attackRange) //if player is not in attack range
            {
                currentState = State.Follow;
            }
            else if (distanceBetweenPlayer <= attackRange && distanceBetweenPlayer >= targetDistance) 
            {
                currentState = State.Attack; //if player is within attack range but not in targetdistance
            }
            else if (distanceBetweenPlayer <= targetDistance)
            {
                currentState = State.Run; //if player is inside the targetdistance
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
