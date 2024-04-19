//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    public bool activeDialog = false;
    public static NPCSystem activeNPC;

    [Space(10)]
    [Header("Relacionados ao dialogo do NPC")]
    public int NPC_ID;
    public NPCSystemDialog dialog;
    public NPCSystemTriggerDetection colliderDection;
    public AudioSource audioSource;

    [Space(10)]
    [Header("Relacionados à UI")]
    public NPCSystemUIController UIController;
    public GameObject UICanvas;

    [Space(10)]
    [Header("Texto para clicar no E")]
    public GameObject UI_Text_NPC;
    public TMP_Text UI_Text_NPC_Name;

    [Space(10)]
    [Header("Relacionados ao player")]
    public PlayerInput playerInput;

    [Space(10)]
    [Header("Relacionados ao capítulo & quest")]
    public ChapterController chapterController;
    public QuestController questController;

    [Space(10)]
    [Header("Relacionados ao inventário & items")]
    public Inventory playerInventory;
    public InventoryItem inventoryItem;

    private void Update()
    {

        if(NPC_ID != colliderDection.NPC_ID)
            return;

        if (colliderDection.playerDetection && !activeDialog && activeNPC != this)
        {
            activeNPC = this;
            UI_Text_NPC.SetActive(true);
            UI_Text_NPC_Name.SetText("Pressiona [E] para falar com " + dialog.NPC_Name);
        }

        if (colliderDection.playerDetection && Input.GetKeyDown(KeyCode.E) && !activeDialog)
        {   
            activeDialog = true;
            playerInput.ReleaseControl();

            UI_Text_NPC.SetActive(false);
            UICanvas.SetActive(true);

            StartCoroutine(DisplayDialog(dialog.dialog_list, dialog.audio_list));
        }
    }

    private IEnumerator DisplayDialog(List<string> dialogList, List<AudioClip> audioList)
    {
        int maxIndex = dialogList.Count - 1;
        int currentIndex = 0;

        while (currentIndex <= maxIndex)
        {
            // Play audio
            AudioClip clip = audioList[currentIndex];
            audioSource.clip = clip;
            audioSource.Play();

            // Set dialog in the UI
            UIController.UpdateUI(dialog.NPC_Name, dialogList[currentIndex]);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            currentIndex++;
        }
        
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        UICanvas.SetActive(false);
        activeDialog = false;
        playerInput.GainControl();

        if(dialog.Quest_ID != -1)
            questController.StartQuest(dialog.Quest_ID);

        if(dialog.Chapter_ID != -1)
            chapterController.StartChapter(dialog.Chapter_ID);

        if(inventoryItem != null && playerInventory != null)
            playerInventory.GiveItem(inventoryItem);
    }


    private void LateUpdate()
    {
        if (!colliderDection.playerDetection && activeNPC == this)
        {
            activeNPC = null;
            UICanvas.SetActive(false);
            UI_Text_NPC.SetActive(false);
        }
    }
}