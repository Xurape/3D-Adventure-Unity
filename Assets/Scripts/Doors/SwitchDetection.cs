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

public class SwitchDetection : MonoBehaviour
{
    [Header("Relacionado com o inventário")]
    public Inventory playerInventory;
    public InventoryItem _item;

    [Header("Relacionado com a UI")]
    public GameObject UI_Canvas;
    public TMP_Text UI_Text;

    [Header("Relacionado com o switch")]
    public SimpleTranslator simpleTranslator;
    public bool isSwitchable = true;
    public bool hasItem = false;

    [Header("Relacionado com as quests")]
    public QuestController questController;
    public int Quest_ID;

    [Header("Relacionado com os chapters")]
    public ChapterController chaptersController;
    public int chapter_ID;

    public void OpenDoor() {
        isSwitchable = false;

        simpleTranslator.PerformInteraction();

        playerInventory.TakeItem(_item);
        playerInventory.UpdateUI();
        
        if(Quest_ID != -1)
            questController.StartQuest(Quest_ID);
    }

    public void LateUpdate() {
        if (hasItem) {
            if(Input.GetKeyDown(KeyCode.E))
                OpenDoor();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isSwitchable)
        {

            if (playerInventory.HasItem(_item))
            {
                OpenDoor();
            }
            else
            {
                UI_Canvas.SetActive(true);
                UI_Text.SetText("Precisas de uma chave secreta para abrires esta porta!");
            }
        }
    }

    public void OnTriggerExit() {
        if(UI_Canvas.activeSelf)
            UI_Canvas.SetActive(false);
    }
}
