using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public SpriteRenderer zSR;
    public Melee_Enemy_Anim_Switcher mSW;


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
        mSW.next_Animation_For_Zombie("Zombie_Walk_Arms");
        mSW.next_Animation_For_Zombie("Zombie_Walk_Legs");

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

    void OnCollisionEnter2D(Collision2D hit)
    {
        //If the zombie collides with the table prop, they'd perform the climbing animation, followed by the walking animation when they're on the table.
        if (hit.gameObject.tag == "Table") {
            mSW.next_Animation_For_Zombie("Zombie_Table_Climb");
           
            mSW.next_Animation_For_Zombie("Zombie_Walk_Arms");
            mSW.next_Animation_For_Zombie("Zombie_Walk_Legs");

        }
    }

    public override void OnTriggerExit2D(Collider2D col)
    {
        moveSpeed = DEFAULT_MSPEED;
        base.OnTriggerExit2D(col);
    }

}
