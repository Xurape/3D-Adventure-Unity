//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NPCSystemDialog : ScriptableObject
{
    public string NPC_Name;
    public int NPC_ID;
    public List<String> dialog_list;
    public List<AudioClip> audio_list;
    public int Chapter_ID = -1;
    public int Quest_ID = -1;
    
    public string GetDialog(int index)
    {
        return dialog_list[index];
    }

    public AudioClip GetAudio(int index)
    {
        return audio_list[index];
    }
}
