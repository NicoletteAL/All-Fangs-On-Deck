using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    Image image;

    public float fadeTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        FadeFromBlack();
        //StartCoroutine(FadeFromBlack());
    }


    public void FadeFromBlack(){

        StartCoroutine(FadeFromBlackRoutine());

        IEnumerator FadeFromBlackRoutine(){
            float timer = 0;
            while(timer < fadeTime){
                timer+= Time.deltaTime;
                image.color = new Color(0,0,0,1 - (timer/fadeTime));
                yield return null;
            }
            image.color = Color.clear;
            yield return null;
        }
    }
    public void FadeToBlack(){

        StartCoroutine(FadeToBlackRoutine());


        IEnumerator FadeToBlackRoutine(){
            float timer = 0;
            while(timer < fadeTime){
                timer += Time.deltaTime;
                image.color = new Color(0,0,0,(timer/fadeTime));
                yield return null;
            }
            image.color = Color.black;
            yield return null;
        }
    }
}
