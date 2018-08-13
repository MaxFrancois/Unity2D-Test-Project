using UnityEngine;

public class CollectableItem : MonoBehaviour {

    public ItemType Type;
    public int Amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var inventory = collision.GetComponent<CharacterInventoryModel>();
            if (inventory != null)
            {
                inventory.AddItem(Type, Amount);
                Destroy(gameObject);
            }
        }
    }
}
