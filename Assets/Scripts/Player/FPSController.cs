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

public class FPSController : MonoBehaviour
{
    public int fps = 120;

    void OnEnable()
    {
        SetTargetFPS(fps);
    }

    public void SetTargetFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }
} 
