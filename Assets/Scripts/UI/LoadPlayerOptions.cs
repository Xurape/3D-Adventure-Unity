//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LoadPlayerOptions : MonoBehaviour
{
    public AudioMixer audioMixerMaster;
    public Slider masterVolumeSlider;
    public AudioMixer audioMixerMusic;
    public Slider musicVolumeSlider;
    public AudioMixer audioMixerEffects;
    public Slider effectsVolumeSlider;
    public AudioMixer audioMixerDialog;
    public Slider dialogVolumeSlider;
    public TMP_Dropdown qualityDropdown;

    public void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            audioMixerMaster.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        }
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            audioMixerMusic.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        }
        if (PlayerPrefs.HasKey("EffectsVolume"))
        {
            effectsVolumeSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
            audioMixerEffects.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("EffectsVolume"));
        }
        if (PlayerPrefs.HasKey("DialogVolume"))
        {
            dialogVolumeSlider.value = PlayerPrefs.GetFloat("DialogVolume");
            audioMixerDialog.SetFloat("DialogVolume", PlayerPrefs.GetFloat("DialogVolume"));
        }
        if (PlayerPrefs.HasKey("QualityLevel"))
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityLevel"));
            qualityDropdown.value = PlayerPrefs.GetInt("QualityLevel");
        }
    }
}
