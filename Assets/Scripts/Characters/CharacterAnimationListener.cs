using UnityEngine;

// set tiny bar events at the top during animations
public class CharacterAnimationListener : MonoBehaviour {

    public CharacterMovementModel MovementModel;
    public CharacterMovementView MovementView;


    public void OnAttackStarted()
    {
        if (MovementModel == null || MovementView == null) return;
        MovementModel.OnAttackStarted();
        MovementView.OnAttackStarted();
        ShowWeapon();
    }

    public void OnAttackEnded()
    {
        if (MovementModel == null || MovementView == null) return;
        MovementModel.OnAttackEnded();
        MovementView.OnAttackEnded();
        HideWeapon();
    }

    public void ShowWeapon()
    {
        MovementView.ShowWeapon();
    }

    public void HideWeapon()
    {
        MovementView.HideWeapon();
    }

    public void SetSortingOrderOfWeapon(int sortingOrder)
    {
        MovementView.SetSortingOrderOfWeapon(sortingOrder);
    }
}
