using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    int hp;
    public ImageFader imageFader;
    bool changingScenes = false;
    public GameObject DeathMusic;
    // Start is called before the first frame update
    void Start()
    {
        hp = Player.instance.GetComponent<PlayerHealth>().currentHealth;
        GetComponent<Canvas>().enabled = false;// Start with the lose menu UI hidden
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) {
            DeathScreen();
        }
    }

    public void DeathScreen() {
        GetComponent<Canvas>().enabled = true; // Show the pause menu UI
        //DeathMusic.GetComponent<AudioSource>.Play();
    }

    public void TitleScreen(){
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

    public void Retry() {
        Time.timeScale = 1f; // Restore the game time
        Player.instance.GetComponent<PlayerHealth>().currentHealth = hp;
        StartCoroutine(ChangeSceneRoutine());
        IEnumerator ChangeSceneRoutine(){
            imageFader.FadeToBlack();
            yield return new WaitForSeconds(imageFader.fadeTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            yield return null;
        }
    }
}
