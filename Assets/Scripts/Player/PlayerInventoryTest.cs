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

public class PlayerInventoryTest : MonoBehaviour
{
    public Inventory playerInventory;
    public InventoryItem item;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
            playerInventory.GiveItem(item);
    }
}
