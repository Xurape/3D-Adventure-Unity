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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public Transform player;
    
    private void LateUpdate()
    {
        Vector3 newPos = player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
        
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
