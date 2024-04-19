//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PlayerInteractOnTrigger : MonoBehaviour
{
    public LayerMask layers;
    public UnityEvent OnEnter, OnExit;
    new Collider collider;
    public Inventory playerInventory;
    public InventoryItem item;
    public String action;

    void Reset()
    {
        layers = LayerMask.NameToLayer("Everything");
        collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            ExecuteOnEnter(other);
        }
    }

    protected virtual void ExecuteOnEnter(Collider other)
    {
        OnEnter.Invoke();
        
        switch(action) {
            case "item":
                playerInventory.GiveItem(item);
                break;

            default:
                break;  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            ExecuteOnExit(other);
        }
    }

    protected virtual void ExecuteOnExit(Collider other)
    {
        OnExit.Invoke();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "InteractionTrigger", false);
    }

    // void OnDrawGizmosSelected()
    // {
    // }
} 