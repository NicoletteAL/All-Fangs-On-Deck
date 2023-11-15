using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public SpriteRenderer zSR;
    public Melee_Enemy_Anim_Switcher mSW;
    public bool isClimbing = false;

    void FixedUpdate()
    {
        //Add idle()
        switch (currentState)
        {
            default:
            case State.Idle:
                Idle();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Follow:
                Move();
                break;
        }
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            mSW.next_Animation_For_Zombie("Zombie_Attack_Arms");

            moveSpeed = 0.0f;
            playerHealth.TakeDamage(damage);
            StartCoroutine(Delay());  
        }
    }

    public void Idle()
    {
        moveSpeed = 0;
        mSW.next_Animation_For_Zombie("Zombie_Idle_Arms");
        mSW.next_Animation_For_Zombie("Zombie_Idle_Legs");
    }
    
    public virtual void Move()
    {
        if (isClimbing == true)
        {
            isClimbing = false;
            transform.Translate(moveSpeed * Time.deltaTime * 0, 1.5f, 0);
            mSW.next_Animation_For_Zombie("Zombie_Table_Climb");
        } 
        else 
        {
            mSW.next_Animation_For_Zombie("Zombie_Walk_Arms");
            mSW.next_Animation_For_Zombie("Zombie_Walk_Legs");
        }

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

    IEnumerator Delay()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Table") 
        {
            Debug.Log("climbing");
            isClimbing = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D col)
    {
        moveSpeed = DEFAULT_MSPEED;
        base.OnTriggerExit2D(col);
    }

}
