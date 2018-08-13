using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDatabase : ScriptableObject {

    public List<ItemData> Data;
    public ItemData FindItem(ItemType type)
    {
        return Data.FirstOrDefault(c => c.Type == type);
    }
}

public enum PickUpAnimation
{
    None,
    OneHand,
    TwoHand
}

public enum EquipSlot
{
    None,
    MainHand,
    OffHand
}

[Serializable]
public class ItemData
{
    
    public ItemType Type;
    public GameObject Prefab;
    public PickUpAnimation Animation;
    public EquipSlot EquipmentSlot;
}
