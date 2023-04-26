using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScene : MonoBehaviour
{
    [Header("Выпадающие списки")]
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;

    Resolution[] resolutions;
    void Start()
    {
        List<string> options = new List<string>();

        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        int counter = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;

            if (resolutions[i].width <= 1000 || resolutions[i].height <= 1000)
            { continue; }
            resolutions[counter] = resolutions[i];
            counter++;
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();

        LoadSettings(currentResolutionIndex);
    }

    public void FullScreenMode(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingsPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    }

    public void LoadSettings(int currentResolutionIndex) 
    {
        if (PlayerPrefs.HasKey("QualitySettingsPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingsPreference");
        else
            qualityDropdown.value = 0;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
           resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            qualityDropdown.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("FullScreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
        else
            Screen.fullScreen = true;
    }
}
