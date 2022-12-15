using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    public int lastSaveSlotId;
    public List<SaveSlot> saveSlots;
}


[Serializable]
public class SaveSlot
{
    public string sceneName;
    public string dateTime;
    public string saveSlotName;
    public PlayerInformation playerInformation;
}

[Serializable]
public class PlayerInformation
{
    public Vector3 playerPos;
    public int playerLevel;

    public Inventory inventory;

}

[Serializable]
public class Inventory
{
    public List<Item> items;
}

[Serializable]
public class Item
{
    public int id;
    public int amount;
}
