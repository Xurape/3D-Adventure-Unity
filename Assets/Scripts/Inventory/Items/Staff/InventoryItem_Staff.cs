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

[CreateAssetMenu(fileName = "InventoryItem_Staff", menuName = "Inventory Items/Staff", order = 1)]
public class InventoryItem_Staff : InventoryItem, IUsableItem
{
    public void Use(PlayerController player)
    {
        player.SetCanAttack(true);
    }

    public void UnUse(PlayerController player)
    {
        player.SetCanAttack(false);
    }
}