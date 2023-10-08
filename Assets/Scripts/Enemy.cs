using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 1.25f;
    public float attackCooldown = 3.0f;
    public float moveSpeed = 1.5f;
    public float DEFAULT_MSPEED = 1.5f;

    public GameObject player;
    public Health playerHealth;

    public CircleCollider2D circleCollider2D;

    public bool isAttacking = false;

    public enum State
    {
        Idle,
        Follow,
        Attack
    }

    public State currentState;

    public virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
        circleCollider2D.radius = attackRange;
    }

    public virtual void Start()
    {
        currentState = State.Follow;
    }

    public virtual void FixedUpdate()
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

    public virtual void Attack()
    {
        if (!isAttacking)
        {
            playerHealth.TakeDamage(damage);
            StartCoroutine(Delay());
        }        
    }

    //should probably be in meleeenemy instead?
    public virtual void Move()
    {
        Vector3 scale = transform.localScale;
        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            transform.Translate(moveSpeed * Time.deltaTime, 0,0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
            transform.Translate(moveSpeed * Time.deltaTime * -1, 0,0);
        }

        transform.localScale = scale;
    }

    IEnumerator Delay()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    public virtual void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            moveSpeed = 0.0f;
            currentState = State.Attack;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D col)
    {
        moveSpeed = DEFAULT_MSPEED;
        currentState = State.Follow;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

