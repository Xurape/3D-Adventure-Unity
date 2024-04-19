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
using UnityEngine;

public class NPCSystemTriggerDetection : MonoBehaviour
{
    public bool playerDetection = false;
    public int NPC_ID;

    private void OnTriggerEnter(Collider colliderObject)
    {
        if (colliderObject.CompareTag("Player"))
        {
            playerDetection = true;
        }
    }

    private void OnTriggerExit(Collider colliderObject)
    {
        if (colliderObject.CompareTag("Player"))
        {
            playerDetection = false;
        }
    }
}
