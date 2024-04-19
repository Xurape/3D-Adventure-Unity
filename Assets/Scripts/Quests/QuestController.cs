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
using TMPro;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public List<Quest> quests;
    public List<GameObject> waypoints;
    public Quest activeQuest;
    public GameObject UI_Canvas;
    public GameObject UI_Panel;
    public TMP_Text UI_Quest_Name;
    public TMP_Text UI_Quest_Description;
    public AudioSource _QuestAudioSource;
    public Animator _QuestAnimator;

    public void Start()
    {
        foreach(var _quest in quests)
            _quest.hasStarted = false;
    }

    public void StartQuest(int QuestNumber)
    {
        if(quests[QuestNumber].hasStarted)
            return;

        activeQuest = quests[QuestNumber];
        waypoints[QuestNumber].SetActive(true);

        if(QuestNumber != 0) {
            waypoints[QuestNumber - 1].SetActive(false);
        }
        quests[QuestNumber].hasStarted = true;
        UpdateUI(activeQuest.name, activeQuest.description, activeQuest.currentQuantity, activeQuest.quantity);
        PlayQuestSound();
    }

    public void NextQuest()
    {
        int nextQuest = activeQuest.number + 1;

        if (nextQuest < quests.Count)
            StartQuest(nextQuest);
    }

    public void UpdateUI(string QuestName, string QuestDescription, int QuestCurrentQuantity, int QuestQuantity)
    {
        UI_Canvas.SetActive(true);
        UI_Quest_Name.SetText(QuestName);
        UI_Quest_Description.SetText(QuestDescription);
        UI_Panel.SetActive(true);
        _QuestAnimator.Play("UI_Quest_Appear");
        PlayQuestSound();

        // _QuestUI.SetActive(false);
        // _QuestUI.SetActive(true);
        // _QuestNumber.SetText(QuestNumber.ToString());
        // _QuestName.SetText(QuestName);
        // _QuestAnimator.Play("UI_Quest_Appear");
    }

    public void PlayQuestSound()
    {
        // _QuestAudioSource.Play();
    }
}
