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

public class SceneLoaderController : MonoBehaviour
{
    public GameObject _loadingScreen;
    public Animator _animator;
    //public Image LoadingBarFill;

    public void StartGame()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NewGame() 
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;

        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }
    
    IEnumerator LoadSceneAsync(int sceneId)
    {
        if(_loadingScreen != null)
            _loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            // LoadingBarFill.fillAmount = progressValue;

            yield return null;
        }

        if(_loadingScreen != null)
            _loadingScreen.SetActive(false);

        if(_animator != null)
            _animator.Play("Fade_out");
    }
}
