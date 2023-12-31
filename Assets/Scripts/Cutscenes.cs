using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{
    public Image[] cutscenes;
    public int i = 1;
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
        if (i < cutscenes.Length - 1)
        {
            i += 1;
            cutscenes[i - 1].enabled = false;
            
            cutscenes[i].enabled = true;
        }
        else
        {
            if (currentScene.name == "Cutscene1")
            {
                SceneManager.LoadScene("Level 1");
            }
            else if (currentScene.name == "Cutscene2")
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
}
