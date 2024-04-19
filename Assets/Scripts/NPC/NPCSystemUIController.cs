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
using TMPro;
using UnityEngine;

public class NPCSystemUIController : MonoBehaviour
{
    public TMP_Text NPC_Name;
    public TMP_Text Dialog;

    public void UpdateUI(String NPC, String NPC_Dialog)
    {
        NPC_Name.SetText(NPC);
        Dialog.SetText(NPC_Dialog);
    }
}
