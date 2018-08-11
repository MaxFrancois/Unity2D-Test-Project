using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterInteractionModel : MonoBehaviour {

    private CharacterMovementModel _movementModel;
    private Character _character;

	void Awake () {
        _movementModel = GetComponent<CharacterMovementModel>();
        _character = GetComponent<Character>();
	}

    public void OnInteract()
    {
        var usableInteractable = FindUsableInteractable();
            if (usableInteractable == null) return;
        usableInteractable.OnInteract(_character);
        
    }

    InteractableBase FindUsableInteractable()
    {
        var closeColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        float angleToClosestInteractable = Mathf.Infinity;
        InteractableBase closestInteractable = null;
        foreach (var collider in closeColliders)
        {
            InteractableBase interactable = collider.GetComponent<InteractableBase>();
            if (interactable == null) continue;

            Vector3 directionToInteractable = collider.transform.position - transform.position;
            var angleToInteractable = Vector3.Angle(_movementModel.GetFacingDirection(), directionToInteractable);
            if (angleToInteractable < 40)
                if (angleToInteractable < angleToClosestInteractable)
                {
                    angleToClosestInteractable = angleToInteractable;
                    closestInteractable = interactable;
                }
        }
        return closestInteractable;
    }
}
