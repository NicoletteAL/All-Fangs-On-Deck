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

    public PlayerHealth health;

    void Awake() {
        if(!instance) { instance = this; } else{ Destroy(gameObject); }
    }

    public void LaunchProjectile()
    {
        Instantiate(projectile, new Vector3(shootSpawn.transform.position.x, shootSpawn.transform.position.y, 0f), Quaternion.identity);
    }

    public void Punch(){
        GameObject hit = Instantiate(melee, new Vector3(meleeSpawn.transform.position.x, meleeSpawn.transform.position.y, 0f), Quaternion.identity);
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
