//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChapterController : MonoBehaviour
{
    public Chapter currentChapter;
    public List<Chapter> chapters;
    public GameObject _chapterUI;
    public TMP_Text _chapterNumber;
    public TMP_Text _chapterName;
    public Animator _chapterAnimator;
    public AudioSource _chapterAudioSource;

    public void Start()
    {
        foreach(var _chapter in chapters)
            _chapter.hasStarted = false;
    }

    public void StartChapter(int chapterNumber)
    {
        if(chapters[chapterNumber].hasStarted)
            return;

        currentChapter = chapters[chapterNumber];
        chapters[chapterNumber].hasStarted = true;
        UpdateUI(currentChapter.number, currentChapter.name);
        PlayChapterSound();
    }

    public void NextChapter()
    {
        int nextChapter = currentChapter.number + 1;

        if (nextChapter < chapters.Count)
            StartChapter(nextChapter);
    }

    public void UpdateUI(int chapterNumber, string chapterName)
    {
        _chapterUI.SetActive(false);
        _chapterUI.SetActive(true);
        _chapterNumber.SetText(chapterNumber.ToString());
        _chapterName.SetText(chapterName);
        _chapterAnimator.Play("UI_Chapter_Appear");
    }

    public void PlayChapterSound()
    {
        _chapterAudioSource.Play();
    }
}
