using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{    
    [Header("Ranged Config")]
    [SerializeField] private float targetDistance;
    [SerializeField] private float distanceBetweenPlayer;

    public GameObject proj;
    public Transform spawner;
    public Ranged_Enemy_Anim_Switcher rangedSW;

    public bool isShooting = false;
    public bool isJumping = false;

    void FixedUpdate()
    {
        //TODO: Add jump when colliding with a table
        switch (currentState)
        {
            default:
            case State.Attack:
                Shoot();
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
       
       if (isJumping) 
       {
            rangedSW.next_Animation_For_Skelly("Skelly_Jump_Arms");
            rangedSW.next_Animation_For_Skelly("Skelly_Jump_Legs");
       }
       else 
       {
            
         rangedSW.next_Animation_For_Skelly("Skelly_Arms_Run");
         rangedSW.next_Animation_For_Skelly("Skelly_Run");
       }

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

    public void Idle()
    {
        moveSpeed = 0;
        rangedSW.next_Animation_For_Skelly("Skelly_Arms_Idle");
        rangedSW.next_Animation_For_Skelly("Skelly_Legs_Idle");
    }


    public void Shoot()
    {
        moveSpeed = 0.75f;

        if (!isShooting)
        {
            rangedSW.next_Animation_For_Skelly("Skelly_Throw");

            var q = Quaternion.AngleAxis(20.0f, Vector3.up);
            GameObject projectile = Instantiate(proj, spawner.transform.position, q);  //spawner.transform.position
            
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        isShooting = true;
        yield return new WaitForSeconds(attackCooldown);
        isShooting = false;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Table") 
        {
            isJumping = true;
        }
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
