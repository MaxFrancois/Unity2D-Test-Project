using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootItemOnDestroy : MonoBehaviour {

    public List<Loot> LootTable;

    private void OnDestroy()
    {
        GenerateLoot();
    }

    private void GenerateLoot()
    {
        var totalPercent = LootTable.Sum(c => c.Percentage);
        if (totalPercent != 100)
        {
            throw new Exception("Loot Percentage != 100%");
        }

        var loot = GetRandomLoot();
        if (loot != null)
        {
            var item = Database.Items.FindItem(loot.ItemType);
            if (item != null && item.Prefab != null)
            {
                Instantiate(item.Prefab, transform.position, Quaternion.identity);
            }
        }
    }

    //http://www.vcskicks.com/random-element.php
    private Loot GetRandomLoot()
    {
        var r = UnityEngine.Random.Range(0, 100);
        LootTable = LootTable.OrderBy(c => c.Percentage).ToList();
        double cumulative = 0.0;
        for (int i = 0; i < LootTable.Count; i++)
        {
            cumulative += LootTable[i].Percentage;
            if (r < cumulative)
            {
                return LootTable[i];
            }
        }
        return null;
    }
}


[Serializable]
public class Loot
{
    public ItemType ItemType;
    public int Amount;
    public float Percentage;
}