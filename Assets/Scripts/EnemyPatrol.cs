using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    public Transform leftEdge;
    public Transform rightEdge;
    public Transform enemy;
    
    public float idleDuration;
    public float idleTimer;
    public float speed;

    private Vector3 initScale;
    private bool movingLeft;


    void Awake()
    {
        initScale = enemy.localScale;
    }

    // Update is called once per frame
    void Update()
    {
            //   moving left           ||     moving right
            //MoveInDirection(-1)    ----- MoveInDirection(1)
        if ((movingLeft && enemy.position.x >= leftEdge.position.x) || (!movingLeft && enemy.position.x <= rightEdge.position.x))
        {
            MoveInDirection(movingLeft ? -1 : 1);
        }
        else
        {
            DirectionChange();
        }
    }

    public void DirectionChange()
    {
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }

    public void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
        enemy.position.y, enemy.position.z);
    }
}
