using System.Collections;
using UnityEngine;

public class AttackableEnemy : AttackableBase {

    public int MaxHealth;
    public GameObject EnemyObject;
    public CharacterMovementModel MovementModel;
    public float PushTime;
    public float PushStrength;
    public float DestroyDelayOnDeath;
    public GameObject DeathFX;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = MaxHealth;
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

    public override void OnAttacked(ItemType itemType, Collider2D collider)
    {
        Vector3 pushDirection = transform.position - collider.gameObject.transform.position;
        pushDirection = pushDirection.normalized * PushStrength;
        MovementModel.PushCharacter(pushDirection, PushTime);
        _currentHealth--;
        if (_currentHealth <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(PushTime);
        var deathAnimation = Instantiate(DeathFX, transform.position, Quaternion.identity);
        Destroy(EnemyObject, DestroyDelayOnDeath);
        Destroy(deathAnimation, DestroyDelayOnDeath);
    }
}
