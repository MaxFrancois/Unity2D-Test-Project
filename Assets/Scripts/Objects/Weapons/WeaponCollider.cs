using UnityEngine;

public class WeaponCollider : MonoBehaviour {

    public ItemType WeaponType;
    Collider2D _weaponCollider;
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    AttackableBase attackable = collision.gameObject.GetComponent<AttackableBase>();
    //    if (attackable != null)
    //        attackable.OnAttacked(WeaponType);
    //}
    private void Awake()
    {
        _weaponCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        AttackableBase attackable = collider.gameObject.GetComponent<AttackableBase>();
        if (attackable != null)
            attackable.OnAttacked(WeaponType, _weaponCollider);
    }
}
