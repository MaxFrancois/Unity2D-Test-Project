using UnityEngine;

public class EnemyCharacterCollision : MonoBehaviour {

    CharacterBatControl _control;

    private void Awake()
    {
        _control = GetComponentInParent<CharacterBatControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _control.OnHitCharacter(collision.gameObject);
        }
    }
}
