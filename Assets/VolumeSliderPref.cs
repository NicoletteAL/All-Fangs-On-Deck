using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public string volumeKey = "Volume";
    

    private Slider slider;
    

    private void Awake()
    {
        slider = GetComponent<Slider>();
        LoadVolume();
    }

    

    public void SaveVolume()
    {
        float volumeValue = slider.value;
        PlayerPrefs.SetFloat(volumeKey, volumeValue);
        PlayerPrefs.Save();
    }

    public void LoadVolume()
    {
        if (PlayerPrefs.HasKey(volumeKey))
        {
            float volumeValue = PlayerPrefs.GetFloat(volumeKey);
            slider.value = volumeValue;
        }
    }
}