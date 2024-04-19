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

public class FallDamage : MonoBehaviour
{
    private float _fallDamageThreshold = 0.3f;
    private Vector3 _lastPosition;
    private float _lastYDelta;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update(){
        /* TODO: IMPLEMENTAÇÃO OPCIONAL - É preciso resolver bugs aqui */
        // if (_playerHealth.HP <= 0) return;

        // var curPosDelta = _lastPosition - transform.position;

        // var yChange = curPosDelta.y - _lastYDelta;
        
        // if (yChange > _fallDamageThreshold && _lastYDelta > 0f){
        //     _playerHealth.damage((int)(yChange * 10));
        // }
        
        // _lastYDelta = curPosDelta.y;
        // _lastPosition = transform.position;
    } 
}