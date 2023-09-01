using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleHandle : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision!");
        if(other.GetComponent<creature>() != null)
        {
            FallingCoin.score = 0;
            //Destroy(this.gameObject);
            SceneManager.LoadScene("MainMenu");
            
        }
    }
}
