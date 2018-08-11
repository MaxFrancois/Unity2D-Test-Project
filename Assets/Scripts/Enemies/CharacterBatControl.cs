using UnityEngine;

public class CharacterBatControl : CharacterBaseControl {

    public float PushStrengh;
    public float PushTime;
    GameObject _characterInRange;

    private void Update()
    {
        UpdateDirections();
    }

    void UpdateDirections()
    {
        Vector2 direction = Vector2.zero;
        if (_characterInRange != null)
        {
            direction = _characterInRange.transform.position - transform.position;
            direction.Normalize();
        }
        SetDirection(direction);
    }

    public void SetIsInRange(GameObject isInRange)
    {
        _characterInRange = isInRange;
    }

    public void OnHitCharacter(GameObject character)
    {
        _characterInRange = null;
        var direction = character.transform.position - transform.position;
        direction.Normalize();
        character.GetComponent<CharacterMovementModel>().PushCharacter(direction * PushStrengh, PushTime);
    }
}
