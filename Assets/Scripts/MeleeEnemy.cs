using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField]
    public float attackCooldown;
    public float range;
    public float colliderDistance;
    public int damage;
    public BoxCollider2D boxCollider;
    public LayerMask playerLayer;

    public Health playerHealth;

    private EnemyPatrol enemyPatrol;

    public bool isAttacking = true;

    void Awake()
    {
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }
    
    void Update()
    {
        if (PlayerInSight() && isAttacking)
        {  
            Debug.Log("attacking");
            DamagePlayer();            
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }  
    }

    public bool PlayerInSight()
    {
        RaycastHit2D hit = PerformBoxCast();

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private RaycastHit2D PerformBoxCast()
    {
        Vector2 castOrigin = boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance;
        Vector3 castSize = new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z);

        return Physics2D.BoxCast(castOrigin, castSize, 0, Vector2.left, 0, playerLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DamagePlayer()
    {
        isAttacking = false;
        playerHealth.TakeDamage(damage);
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = true;
    }
}
