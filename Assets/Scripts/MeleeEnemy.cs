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

    private float cooldownTimer = Mathf.Infinity;

    public Health playerHealth;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {  
            Debug.Log("attacking");
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
            }  
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
        if (PlayerInSight())
        {
            Debug.Log("test");
            playerHealth.TakeDamage(damage);
        }
    }
}
