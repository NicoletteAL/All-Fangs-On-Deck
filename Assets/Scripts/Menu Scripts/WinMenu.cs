using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public ImageFader imageFader;
    bool changingScenes = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("owo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void TitleScreen(){
        Debug.Log("click");
        if(changingScenes){
            return;
        }
        changingScenes = true;
        Time.timeScale = 1f; // Restore the game time
        StartCoroutine(ChangeSceneRoutine());
        IEnumerator ChangeSceneRoutine(){
            imageFader.FadeToBlack();
            yield return new WaitForSeconds(imageFader.fadeTime);
            SceneManager.LoadScene(0);
            yield return null;
        }
        
    }
}
