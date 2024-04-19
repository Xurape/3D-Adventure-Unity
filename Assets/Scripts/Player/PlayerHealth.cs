//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using System.Net;
using Gamekit3D;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float HP = 100;
    public TMP_Text HPText;
    public Slider healthBar;
    public bool godmode = false;
    public UnityEvent OnDeath, OnReceiveDamage, OnHitWhileInvulnerable, OnBecomeVulnerable, OnResetDamage;
    public PlayerController playerController;
    
    public void Start() {
        HP = 100;
        UpdateUI();
    }

    public void damage(int damage) {
        if (godmode) return;

        HP -= damage;

        if (HP <= 0) {
            OnDeath.Invoke();
            playerController.KillPlayer();
        }

        UpdateUI();
    }

    public void setHealth(int hp) {
        HP = hp;
    }

    public void heal(int heal) {
        if(HP == 100) return;

        HP += heal;

        UpdateUI();
    }

    public void kill()
    {
        playerController.KillPlayer();
    }

    public void respawn()
    {
        setHealth(100);
        playerController.Respawn();
        Invoke(nameof(tpToSpawn), 3f);
    }

    public void tpToSpawn()
    {
        transform.position = new Vector3(1.090324f, 30.55f, 1.7f);
    }

    public void UpdateUI() {
        healthBar.value = (float) (HP / 100);
    }
}
