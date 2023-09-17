using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /*
        Enemy state controller
            * patrolling
            * follow / attack
            * retreat (?)
            * on death
            * take damage

            ToDo: make separate scripts to handle all the points 
    */

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    
    [SerializeField] 
    public float speed; 
    public int damage;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Patrolling State
        Vector2 point = currentPoint.position - transform.position;

        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed,0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            if (currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
            }
            else if (currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
            }
            Flip();
        }
        //TODO: switch case for different enemy states

    }

    //TODO: migrate code in the update function to this function
    public void Patrol(bool isEnabled)
    {
        if (isEnabled == true)
        {

        }
    }

    //Flip Sprite
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    //Point Visualizer
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
