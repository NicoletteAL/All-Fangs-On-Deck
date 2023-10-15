using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{    
    [Header("Ranged Config")]
    [SerializeField] private float targetDistance;
    [SerializeField] private float distanceBetweenPlayer;

    void Start()
    {
        currentState = State.Idle;
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
                Move(false);
                break;
            case State.Idle:
                Idle();
                break;
            case State.Run:
                Move(true);
                break;
        }
    }

    public void Move(bool isRunning) 
    {
       moveSpeed = DEFAULT_MSPEED;
       float positionX = transform.position.x - Player.instance.transform.position.x;
       Vector2 direction = new Vector2(positionX, 0);

       if (isRunning)
       {
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
       }
       else 
       {
             transform.Translate(-direction.normalized * moveSpeed * Time.deltaTime);
       }
    }

    public override void Attack()
    {
        Debug.Log("attacking");
        moveSpeed = 0.75f;
        base.Attack();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            currentState = State.Attack;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            currentState = State.Follow;
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            distanceBetweenPlayer = Mathf.Abs(transform.position.x - Player.instance.transform.position.x);
          
            if (distanceBetweenPlayer <= targetDistance)
            {
                currentState = State.Run;
                Debug.Log("Running");
            }
        }
    }

    //yellow shows trigger range, red shows target distance
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetDistance);
    }
    



}
