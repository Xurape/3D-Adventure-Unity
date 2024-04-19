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
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _optionsMenu;
    public GameObject _blackScreen;
    public AudioSource _soundtrack;
    public bool _isPaused;
    
    void Start()
    {
        _isPaused = false;
        _pauseMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _blackScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_optionsMenu.activeSelf) {
                CloseOptions();
                ResumeGame();  
            } else if (_isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        if(_isPaused) {
            if(Input.anyKeyDown) {
                return;
            }
        }
    }

    public void ResumeGame()
    {
        _soundtrack.UnPause();
        _blackScreen.SetActive(false);
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void PauseGame()
    {
        _soundtrack.Pause();
        _blackScreen.SetActive(true);
        _pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void OpenOptions()
    {
        _optionsMenu.SetActive(true);
        _pauseMenu.SetActive(false);
    }

    public void CloseOptions()
    {
        _optionsMenu.SetActive(false);
        _pauseMenu.SetActive(true);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        _isPaused = false;
        SceneManager.LoadScene(0);
    }
}
