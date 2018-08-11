using UnityEngine;

public class WeaponCollider : MonoBehaviour {

    public ItemType WeaponType;
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    AttackableBase attackable = collision.gameObject.GetComponent<AttackableBase>();
    //    if (attackable != null)
    //        attackable.OnAttacked(WeaponType);
    //}
    private void OnTriggerEnter2D(Collider2D collider)
    {
        AttackableBase attackable = collider.gameObject.GetComponent<AttackableBase>();
        if (attackable != null)
            attackable.OnAttacked(WeaponType);
    }
}
