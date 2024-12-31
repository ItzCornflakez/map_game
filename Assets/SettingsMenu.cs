using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int screenResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if( resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                screenResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = screenResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Function to handle the dropdown value change
    public void OnScreenModeChanged(int index)
    {
        switch (index)
        {
            case 0:
                // Exclusive Fullscreen
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.ExclusiveFullScreen);
                Debug.Log("Switched to Exclusive Fullscreen");

                break;

            case 1:
                // Fullscreen borderless
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
                Debug.Log("Switched to Fullscreen Borderless");

                break;

            case 2:
                // Windowed
                Screen.SetResolution(1280, 720, FullScreenMode.Windowed); // Example resolution
                Debug.Log("Switched to Windowed Mode");

                break;

            default:
                Debug.LogWarning("Unknown screen mode index: " + index);
                break;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);

    }

    public void SetAudioText (float volume)
    {

        int newValue = Mathf.RoundToInt((volume + 80) * 100 / 80);

        GameObject.Find("MasterVolumeText").GetComponent<TextMeshProUGUI>().text = $"{newValue}";
    }

    public void SetQuality (int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
