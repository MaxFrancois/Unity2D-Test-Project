using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryModel : MonoBehaviour
{
    private Dictionary<ItemType, int> _items = new Dictionary<ItemType, int>();
    private CharacterMovementModel _movementModel;

    private void Awake()
    {
        _movementModel = GetComponent<CharacterMovementModel>();
    }

    public void AddItem(ItemType type, int quantity = 1)
    {
        if (_items.ContainsKey(type))
            _items[type] += quantity;
        else
            _items.Add(type, quantity);

        if (quantity > 0)
        {
            var itemData = Database.Items.FindItem(type);
            if (itemData.Animation != PickUpAnimation.None)
            {
                _movementModel.ShowItemPickup(itemData.Type);
            }
            if (itemData != null && itemData.EquipmentSlot != EquipSlot.None)
            {
                _movementModel.EquipItem(type);
            }
        }
    }

    public void RemoveItem(ItemType type, int quantity = 1)
    {
        if (_items.ContainsKey(type) && quantity < _items[type])
            _items[type] -= quantity;
        else
            _items.Remove(type);
    }

    public int GetItemCount(ItemType itemType)
    {
        if (_items.ContainsKey(itemType))
        {
            return _items[itemType];
        }
        return 0;

    }
}
