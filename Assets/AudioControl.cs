using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public AudioMixer myAudioMixer;
    public Slider MasterSlider;
    public Slider MusicSlider;

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
}
