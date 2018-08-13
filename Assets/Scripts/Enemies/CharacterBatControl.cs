using UnityEngine;

public class CharacterBatControl : CharacterBaseControl {

    public float PushStrengh;
    public float PushTime;
    GameObject _characterInRange;
    public AttackableEnemy AttackableEnemy;

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
        if (AttackableEnemy != null && AttackableEnemy.GetHealth() <= 0)
        {
            direction = Vector2.zero;
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
        var view = character.GetComponent<CharacterMovementView>();
        view.OnAttackEnded();
        var model = character.GetComponent<CharacterMovementModel>();
        model.OnAttackEnded();
        model.PushCharacter(direction * PushStrengh, PushTime);
    }
}
