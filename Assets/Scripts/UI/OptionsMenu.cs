//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixerMaster;
    public AudioMixer audioMixerMusic;
    public AudioMixer audioMixerEffects;
    public AudioMixer audioMixerDialog;

    public void SetMasterVolume(float value)
    {
        audioMixerMaster.SetFloat("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
        Save();
    }
    
    public void SetMusicVolume(float value)
    {
        audioMixerMusic.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
        Save();
    }
    
    public void SetEffectsVolume(float value)
    {
        audioMixerEffects.SetFloat("EffectsVolume", value);
        PlayerPrefs.SetFloat("EffectsVolume", value);
        Save();
    }
    
    public void SetDiagVolume(float value)
    {
        audioMixerDialog.SetFloat("DialogVolume", value);
        PlayerPrefs.SetFloat("DialogVolume", value);
        Save();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityLevel", qualityIndex);
        Save();
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }
}
