using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleOptions : OptionsMenu
{
    public ImageFader imageFader;
    public Image winCheck;
    public Image fullCheck;
    // Start is called before the first frame update
    void Start()
    {
        fullCheck.enabled = false;
        winCheck.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TitleScreen(){
        StartCoroutine(ChangeSceneRoutine());
        IEnumerator ChangeSceneRoutine(){
            imageFader.FadeToBlack();
            yield return new WaitForSeconds(imageFader.fadeTime);
            SceneManager.LoadScene(0);
            yield return null;
        }
        
    }

    public void SetFull(){
        if (fullCheck.enabled == false) {
            fullCheck.enabled = true;
            winCheck.enabled = false;
            SetFullscreen(true);
        }
    }

    public void SetWindow(){
        if (winCheck.enabled == false) {
            winCheck.enabled = true;
            fullCheck.enabled = false;
            SetFullscreen(false);
        }
    }
}
