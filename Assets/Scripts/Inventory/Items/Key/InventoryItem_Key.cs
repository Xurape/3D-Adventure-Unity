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

[CreateAssetMenu(fileName = "InventoryItem_Key", menuName = "Inventory Items/Key", order = 1)]
public class InventoryItem_Key : InventoryItem, IUsableItem
{
    public void Use(PlayerController player)
    {
        
    }

    public void UnUse(PlayerController player)
    {
        
    }
}