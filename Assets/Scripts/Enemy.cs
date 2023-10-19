using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Config")]
    public int damage = 10;
    public float attackRange = 1.25f;
    public float attackCooldown = 3.0f;
    public float moveSpeed = 1.5f;
    public float DEFAULT_MSPEED = 1.5f;
    public bool isAttacking = false;

    [Header("Objects")]
    public PlayerHealth playerHealth;
    public CircleCollider2D circleCollider2D;

    public enum State
    {
        Attack,
        Follow,
        Idle,
        Run
    }

    [Header("State")]
    public State currentState;

    void Start()
    {
        playerHealth = Player.instance.GetComponent<PlayerHealth>();
        currentState = State.Follow;
    }

    public virtual void Idle()
    {
        Debug.Log("In idle state");
        moveSpeed = 0.0f;
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            currentState = State.Attack;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            currentState = State.Follow;
        }
    }

    public virtual void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

