using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI game object
    public GameObject controls; // Reference to the control menu UI game object
    private bool isPaused = false; // Flag to track if the game is paused
    //public AudioMixer myAudioMixer;

    public AudioMixer myAudioMixer;
    public Slider MasterSlider;
    public Slider MusicSlider;

    private const float targetAspect = 16f / 9f; // Set your desired aspect ratio here
    private Camera mainCamera;
    private bool isFullscreen = true;



     
    
   // Reference to the MasterAudio UI slider // Event triggered when switching to fullscreen mode

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;// Start with the pause menu UI hidden
        controls.GetComponent<Canvas>().enabled = false;
        mainCamera = Camera.main;
        //GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Debug.Log("Paused");
        Time.timeScale = 0f; // Freeze the game time
        isPaused = true;
        GetComponent<Canvas>().enabled = true; // Show the pause menu UI
    }

    public void ResumeGame()
    {
        Debug.Log("Resumed");
        Time.timeScale = 1f; // Restore the game time
        isPaused = false;
        GetComponent<Canvas>().enabled = false;// Hide the pause menu UI
    }

    /*
    public void ChangeScreen()
    {
        Screen.fullScreen = !Screen.fullScreen; // Set fullscreen mode
    }
    */
    public void SetFullscreenMode()
    {
        if (!isFullscreen) // Check if not already in fullscreen mode
        {
            SetFullscreen(true);
            isFullscreen = true;
        }
    }

    // Function to set the game to windowed mode
    public void SetWindowedMode()
    {
        if (isFullscreen) // Check if not already in windowed mode
        {
            SetFullscreen(false);
            isFullscreen = false;
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        // Adjust camera size to match the aspect ratio
        float currentAspect = (float)Screen.width / Screen.height;
        float orthoSize = mainCamera.orthographicSize;

        if (currentAspect < targetAspect)
        {
            // The screen is narrower (black bars on sides)
            orthoSize = mainCamera.orthographicSize * (targetAspect / currentAspect);
        }
        else
        {
            // The screen is wider (black bars on top/bottom)
            orthoSize = mainCamera.orthographicSize;
        }

        mainCamera.orthographicSize = orthoSize;
    }
   

    public void QuitGame(){
        Application.Quit();
    }
    
    public void SetMusicVolume()
    {
        
        float volume = MusicSlider.value;
        myAudioMixer.SetFloat("MusicSlider",Mathf.Log10(volume)*20);
    }

    public void SetMasterVolume()
    {
        float volume = MasterSlider.value;
        myAudioMixer.SetFloat("MasterSlider",Mathf.Log10(volume)*20);
    }

    public void ShowControls() { // Have a control list
        controls.GetComponent<Canvas>().enabled = true;
    }

    public void HideControls() {
        controls.GetComponent<Canvas>().enabled = false;
    }
        
}
