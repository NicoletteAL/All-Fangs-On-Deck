using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public static Player Instance { get { return instance; } }
    public GameObject projectile;
    public GameObject melee;
    public GameObject meleeSpawn;
    public GameObject shootSpawn;
    public Animator animator;

    public PlayerHealth health;

    bool right = true;

    void Awake() {
        if(!instance) { instance = this; } else{ Destroy(gameObject); }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) { //determine spawn position and projectile direction
            right = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            right = false;
        }
        
    }

    public void LaunchProjectile()
    {
        GameObject p = Instantiate(projectile, new Vector3(shootSpawn.transform.position.x, shootSpawn.transform.position.y, 0f), Quaternion.identity);
        p.transform.localScale = new Vector3(1, 1, 1);
        Projectile x = p.GetComponent<Projectile>();
        x.right = right;
    }

    public void Punch(){
        GameObject hit = Instantiate(melee, new Vector3(meleeSpawn.transform.position.x, meleeSpawn.transform.position.y, 0f), Quaternion.identity, meleeSpawn.transform);
        hit.transform.localScale = new Vector3(0.5f,0.3f,0.5f);
        hit.GetComponent<Hitbox>().setDir(right);
        animator.SetTrigger("Attack");
        Destroy(hit, 0.25f);
    }

  
        
    

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colObject = col.gameObject;
        switch (colObject.tag)
        {
            case "Item":
                if (health.currentHealth != health.maxHealth)
                {
                    health.GainHealth(50); //temp value
                    Destroy(col.gameObject);
                }
                break;
            case "Checkpoint":
                int currentLvl = colObject.GetComponent<Checkpoint>().nextScene;
                SwitchLevel(currentLvl);
                break;
        }
    }

    public void SwitchLevel(int index)
    {        
        CheckpointHandler checkpointHandler = FindObjectOfType<CheckpointHandler>();
        checkpointHandler.SwitchScenes(index); 
    }
}
