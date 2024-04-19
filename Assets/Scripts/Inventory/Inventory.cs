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
using Gamekit3D;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new();
    public int inventoryCapacity = 4;
    public int currentSlot = 0;
    public GameObject UI_Inventory;
    public RawImage[] UI_Slots;
    public RawImage[] UI_Slots_Sprite;
    private bool IsFull() => items.Count == inventoryCapacity;
    private PlayerController _player;
    public InventoryUIController _inventoryUIController;
    public GameObject _inventoryUINotification;

    public void Start() {
        _player = GetComponent<PlayerController>();

        UI_Inventory.SetActive(true);

        for(int i = 0; i < inventoryCapacity; i++) {
            items.Add(null);
        }

        foreach(var _slot in UI_Slots) {
            _slot.color = new Color(1, 1, 1, 0.5f);
        }

        setCurrentSlot(0);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) setCurrentSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) setCurrentSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) setCurrentSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) setCurrentSlot(3);
    }

    public void UpdateUI() {
        if(items.Count == 0) return;

        for(int i = 0; i < inventoryCapacity; i++) {
            if(items[i] != null) {
                UI_Slots_Sprite[i].texture = items[i].icon.texture;
                UI_Slots_Sprite[i].color = new Color(1, 1, 1, 1f);
            } else
                UI_Slots_Sprite[i].texture = null;
                UI_Slots_Sprite[i].color = new Color(1, 1, 1, 0f);
        }
    }

    public int getCurrentSlot() => currentSlot;

    public void setCurrentSlot(int slot) {
        if(slot > inventoryCapacity || slot < 0)
            Debug.LogError("Inventory overflow");

        /**
        *
        * Para obtermos um alpha pretendido
        * o que podemos fazer é multiplicar o float
        * por 256. Ou seja 0.5f * 256 = 128 ALPHA
        *
        */
        UI_Slots[slot].color = new Color(1, 1, 1, 1f);

        foreach(var _slot in UI_Slots) {
            if(_slot != UI_Slots[slot])
                _slot.color = new Color(1, 1, 1, 0.5f);
        }

        currentSlot = slot;

        UseItem();
    }

    public List<InventoryItem> GetPlayerInventory() => items;
    
    public InventoryItem GetPlayerInventorySlot(int slot)
    {
        if (slot < 0 || slot > inventoryCapacity)
            Debug.LogError("Inventory overflow");

        return items[slot];
    }

    public bool HasItem(InventoryItem item) => items.Contains(item);

    public void GiveItem(InventoryItem item) { 
        if(HasItem(item)) return;

        if (!IsFull()) items.Add(item); 

        for(int i = 0; i < inventoryCapacity; i++) {
            if(items[i] == null) {
                items[i] = item;
                UI_Slots_Sprite[i].texture = items[i].icon.texture;
                UI_Slots_Sprite[i].color = new Color(1, 1, 1, 1f);
                break;
            }
        }

        _inventoryUIController.ShowNotification(_inventoryUINotification, "ITEM OBTIDO", item.name);

        UseItem();
    }

    public void TakeItem(InventoryItem item) {
        if(HasItem(item)) {
            items.Remove(item);
            items.Add(null);
        }
            
        UpdateUI();
    }

    public void UseItem()
    {
        for (int i = 0; i < inventoryCapacity; i++)
        {
            if (i == currentSlot)
            {
                if (items[i] is IUsableItem usableItem)
                {
                    usableItem.Use(_player);
                }
            }
            else
            {
                if (items[i] is IUsableItem usableItem)
                {
                    usableItem.UnUse(_player);
                }
            }
        }
    }
}