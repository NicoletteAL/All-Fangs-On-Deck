using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{
    public Image[] cutscenes;
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        cutscenes[0].enabled = true;
        for(int i=1; i < 5; i++)
        {
            cutscenes[i].enabled = false;
        }
    }

    public void onClick()
    {
        if (i <= 3) 
        {
            i += 1;
            cutscenes[i-1].enabled = false;
            cutscenes[i].enabled = true;
        } else {
            SceneManager.LoadScene("Level 1");
        }

    }
}
