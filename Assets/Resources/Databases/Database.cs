using UnityEngine;

public class Database
{
    private static ItemDatabase _itemDB;
    public static ItemDatabase Items
    {
        get {
            if (_itemDB == null)
                _itemDB = Resources.Load<ItemDatabase>("Databases/ItemDatabase");
            return _itemDB;
        }
    }

    //private static LootDatabase _lootDB;
    //public static LootDatabase Loots
    //{
    //    get
    //    {
    //        if (_lootDB == null)
    //            _lootDB = Resources.Load<LootDatabase>("Databases/LootDatabase");
    //        return _lootDB;
    //    }
    //}
}
