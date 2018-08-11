using UnityEngine;

public class CharacterBaseControl : MonoBehaviour {

    protected CharacterMovementModel MovementModel;
    protected CharacterInteractionModel InteractionModel;
    protected CharacterMovementView MovementView;

    private void Awake()
    {
        MovementModel = GetComponent<CharacterMovementModel>();
        MovementView = GetComponent<CharacterMovementView>();
        InteractionModel = GetComponent<CharacterInteractionModel>();
    }

    protected void SetDirection(Vector2 direction)
    {
        if (MovementModel == null) return;
        MovementModel.SetDirection(direction);
    }

    protected void OnActionPressed()
    {
        if (InteractionModel == null) return;
        InteractionModel.OnInteract();  
    }

    protected void OnAttackPressed()
    {
        if (MovementModel == null || MovementView == null) return;
        if (MovementModel.CanAttack())
        {
            MovementModel.DoAttack();
            MovementView.DoAttack();
        }
    }
}
