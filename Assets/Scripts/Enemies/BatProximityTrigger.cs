using UnityEngine;

public class BatProximityTrigger : MonoBehaviour {

    CharacterBatControl _control;
    private void Awake()
    {
        _control = GetComponentInParent<CharacterBatControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _control.SetIsInRange(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _control.SetIsInRange(null);
        }
    }
}
