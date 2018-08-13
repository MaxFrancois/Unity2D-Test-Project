using UnityEngine;
using UnityEngine.UI;

public class UIItemCounter : MonoBehaviour {

    public CharacterInventoryModel Inventory;
    public ItemType ItemType;
    public string NumberFormat;
    Text _text;

	void Awake () {
        _text = GetComponent<Text>();
	}
	
	void Update () {
        if (Inventory == null) return;
        _text.text = Inventory.GetItemCount(ItemType).ToString(string.IsNullOrEmpty(NumberFormat) ? "000" : NumberFormat);
	}
}
