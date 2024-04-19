//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using Gamekit3D.GameCommands;
using TMPro;
using UnityEngine;

public class DoorPlayerDetection : MonoBehaviour
{
    [Header("Relacionado com o inventário")]
    public Inventory playerInventory;
    public InventoryItem item;

    [Header("Relacionado com a UI")]
    public GameObject UI_Canvas;
    public TMP_Text UI_Text;

    [Header("Relacionado com a porta")]
    public SimpleTranslator simpleTranslator;
    public bool isOpened = false;
    public bool isOpenable = true;
    public bool playerDetected = false;
    public bool hasItem = false;

    [Header("Relacionado com as quests")]
    public QuestController questController;
    public int Quest_ID;

    public void OpenDoor() {
        isOpenable = false;
        isOpened = true;
        UI_Canvas.SetActive(false);
        simpleTranslator.PerformInteraction();

        playerInventory.TakeItem(item);
        
        if(Quest_ID != -1)
            questController.StartQuest(Quest_ID);
    }

    public void LateUpdate() {
        if (hasItem && playerDetected) {
            if(Input.GetKeyDown(KeyCode.E) && !isOpened)
                OpenDoor();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isOpenable && !isOpened)
        {
            playerDetected = true;

            UI_Canvas.SetActive(true);

            if (playerInventory.HasItem(item))
            {
                UI_Text.SetText("Pressiona [E] para abrir a porta do templo!");
                hasItem = true;
            }
            else
            {
                UI_Text.SetText("Precisas de uma chave secreta para abrires esta porta!");
                hasItem = false;
            }
        }
    }

    public void OnTriggerExit() {
        UI_Canvas.SetActive(false);
        playerDetected = false;
    }
}
