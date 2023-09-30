using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public ImageFader imageFader;
    // Start is called before the first frame update
    public void PrintHello(){
        Debug.Log("Hello!");
    }

    bool changingScenes = false;
    public void ChangeScene(string sceneName ){
        if(changingScenes){
            return;
        }
        changingScenes = true;
        StartCoroutine(ChangeSceneRoutine());
        IEnumerator ChangeSceneRoutine(){
            imageFader.FadeToBlack();
            yield return new WaitForSeconds(imageFader.fadeTime);
            SceneManager.LoadScene(sceneName);
            yield return null;
        }
        
    }

    public void QuitGame(){
        Application.Quit();
    }
}
