using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer am;
    public Toggle toggle1;
    public Toggle toggle2;
    public Slider slider1;
    public Slider slider2;

    public void MusicVolume(float slider2Value)
    {
        am.SetFloat("music", slider2Value);
    }

    public void AudioVolume(float slider1Value)
    {
        am.SetFloat("master", slider1Value);
    }

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        toggle1.onValueChanged.AddListener(delegate {
            Toggle1ValueChanged(toggle1);
        });
        toggle2.onValueChanged.AddListener(delegate {
            Toggle2ValueChanged(toggle2);
        });
    }

    void Toggle1ValueChanged(Toggle change)
    {
            audioSource.mute = !audioSource.mute;
    }

    void Toggle2ValueChanged(Toggle change)
    {
            QualitySettings.shadowDistance = 0f;
    }
}

