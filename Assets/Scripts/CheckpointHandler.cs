using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointHandler : MonoBehaviour
{
   /*
     Current build array
     0 - main menu
     1 - level 1
     2 - level 2
     3 - boss fight
     4 - lose screen 
   */
   Scene scene;
   public int currentScene;

   void Start() 
   {
        scene = SceneManager.GetActiveScene();
        currentScene = scene.buildIndex;
   }

   public void LoadMainMenu() 
   {
        SceneManager.LoadScene(0);
   }

   public void LoadGame() 
   {
        SceneManager.LoadScene(1);
   }

   public void SwitchScenes(int x)
   {
     //x would be the build index
     SceneManager.LoadScene(x);
   }

}
