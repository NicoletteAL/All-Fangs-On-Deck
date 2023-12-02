using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{
    public Image[] cutscenes;
    public int i = 0;
    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        cutscenes[0].enabled = true;
        for(int i=1; i < cutscenes.Length; i++)
        {
            cutscenes[i].enabled = false;
        }
    }

    public void onClick()
    {
        cutscenes[i-1].enabled = false;
        i += 1;

        if (i < cutscenes.Length) 
        {
            cutscenes[i].enabled = true;
        } else {
            if (currentScene.name == "Cutscene1")
            {
                SceneManager.LoadScene("Level 1");
            } else if (currentScene.name == "Cutscene2")
            {
                SceneManager.LoadScene("WinScreen");
            }
        }

        
    }
}
