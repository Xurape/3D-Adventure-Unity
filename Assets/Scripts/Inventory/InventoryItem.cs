//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using Gamekit3D;
using UnityEngine;

[CreateAssetMenu]
public class InventoryItem : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public float? quantity;

    [TextArea]
    public string description;
}
