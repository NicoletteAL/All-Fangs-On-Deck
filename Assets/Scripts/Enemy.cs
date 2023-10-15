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

    //ranged doesnt need this
    public virtual void Attack()
    {
        if (!isAttacking)
        {
            //playerHealth.TakeDamage(damage);
            StartCoroutine(Delay());  
        }
    }

    public virtual void Move()
    {
        Vector3 scale = transform.localScale;
        if (Player.instance.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            transform.Translate(moveSpeed * Time.deltaTime * 1, 0,0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
            transform.Translate(moveSpeed * Time.deltaTime * -1, 0,0);
        }

        transform.localScale = scale;        
    }

    public virtual void Idle()
    {
        Debug.Log("In idle state");
        moveSpeed = 0.0f;
    }

    IEnumerator Delay()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    public virtual void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

