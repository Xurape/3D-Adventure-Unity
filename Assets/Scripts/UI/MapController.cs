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
using UnityEngine;

public class MapController : MonoBehaviour
{
    public Transform player;
    public GameObject UI_Map;
    public Animator _animation;
    public bool isOpen = false;
    public List<AudioSource> audioSources;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(!isOpen) {
                _animation.SetBool("shouldOpen", true);
                isOpen = true;
                Invoke(nameof(PlayRandomAudio), 0.75f);
            } else {
                _animation.SetBool("shouldOpen", false);
                _animation.SetBool("shouldClose", true);
                _animation.Play("UI_Map_Close");
                _animation.SetBool("shouldOpen", false);
                _animation.SetBool("shouldClose", false);
                isOpen = false;
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 newPos = player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }

    public void PlayRandomAudio() {
        int randomIndex = Random.Range(0, audioSources.Count);
        audioSources[randomIndex].Play();
    }
}
