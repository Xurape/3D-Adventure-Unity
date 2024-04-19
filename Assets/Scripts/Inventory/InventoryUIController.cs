//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using TMPro;
using UnityEngine;

public class InventoryUIController: MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text item;
    public Animator animator;

    public void ShowNotification(GameObject UI, string title, string item)
    {
        UI.SetActive(false);
        UI.SetActive(true);
        this.title.text = title;
        this.item.text = item;
    }
}
