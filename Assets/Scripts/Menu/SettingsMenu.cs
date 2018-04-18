using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public Slider volumeSlider;

    void Awake()
    {
        if (volumeSlider) // if there's a game object attached to the public slider then the slider value is the audio volume
        {
            AudioListener.volume = PlayerPrefs.GetFloat("MusicVolume"); // get the stored float value from playerpref
            volumeSlider.value = AudioListener.volume; // set the slider's value to the volume value from music volume playerpref
        }

    }

    public void VolumeHandler(float Volume) // dynamic float value that can be changed by a slider
    {
        AudioListener.volume = Volume;
        PlayerPrefs.SetFloat("MusicVolume", AudioListener.volume); // set float value of audio to a playerpref
    }

    public void SetFullScreen(bool FullScreen)
    {
        Screen.fullScreen = FullScreen;
    }
}
