using UnityEditor;
using UnityEngine;

public class ItemDatabaseCreator : MonoBehaviour {

    [MenuItem("Rafal/Databases/Create Item Database")]
    public static void CreateItemDatabase()
    {
        var db = ScriptableObject.CreateInstance<ItemDatabase>();
        AssetDatabase.CreateAsset(db, "Assets/ItemDatabase.asset");
        AssetDatabase.Refresh();
    }
}
