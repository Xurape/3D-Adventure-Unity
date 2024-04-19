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

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public int number;
    public new string name;

    [TextArea]
    public string description;

    public int quantity;
    public int currentQuantity;

    public bool hasStarted = false;
}