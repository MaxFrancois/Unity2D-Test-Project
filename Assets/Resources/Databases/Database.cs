using UnityEngine;

public class Database
{
    private static ItemDatabase _db;
    public static ItemDatabase Items
    {
        get {
            if (_db == null)
                _db = Resources.Load<ItemDatabase>("Databases/IteMDatabase");
            return _db;
        }
    }
}
