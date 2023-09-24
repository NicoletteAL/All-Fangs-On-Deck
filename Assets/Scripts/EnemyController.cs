using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /*
        Enemy state controller
            * patrolling
            * attack by melee i guess
            * on death
    */
     private enum State {
        Attack,
        Die,
        Patrol
    }

    public GameObject pointA;
    public GameObject pointB;
    
    private float DMG_DELAY = 3.5f; //3 second delay before getting damaged again
    private Rigidbody2D rb;
    private State state;
    private Transform currentPoint;

    public creature c;
    
    [Header("Enemy Stats")]
    [SerializeField] 
    public float speed; 
    public int damage;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        state = State.Patrol;
    }

    // Update is called once per frame
    void Update()
    {   
        //TODO: switch case for different enemy states (?)
        switch (state)
        {
            default:
            case State.Patrol:
                Patrol();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Die:
                OnDeath();
                break;
        }

    }

    /*Enemy State functions*/
    public void Attack()
    {
        //Maybe for ranged enemies?
        
    }

    public void Patrol()
    {
        Vector2 point = currentPoint.position - transform.position;
        Vector2 targetVelocity = (currentPoint == pointB.transform) ? new Vector2(speed, 0) : new Vector2(-speed, 0);

        rb.velocity = targetVelocity;

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            currentPoint = (currentPoint == pointA.transform) ? pointB.transform : pointA.transform;
            Flip();
        }
    }


    /*Collisions*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            c.TakeDamage(damage);
        }
        StartCoroutine(DamageDelay());
    }

    IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(DMG_DELAY);
    }

    /*Health Functions*/
    public void TakeDamage(int d)
    {
        Debug.Log("enemy took damage");
        health -= d;
        if (health <= 0) 
        {
            //Destroy game object
            Destroy(gameObject);
            //add to score/numkills if we decide to track it
        }
    }

    private void OnDeath()
    {
        //change sprite to dead body maybe
    }

    /*Flip Sprite*/
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    /*Point Visualizer*/
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

 
}
