using UnityEngine;

public class InteractableChest : InteractableBase {


    public Sprite OpenChestSprite;
    private bool _isOpen = false;
    public ItemType ItemInChest;
    public int Amount;
	// Use this for initialization

    public override void OnInteract(Character character)
    {
        if (!_isOpen)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = OpenChestSprite;
            _isOpen = true;
            character.Inventory.AddItem(ItemInChest, Amount);
        }
    }
}
