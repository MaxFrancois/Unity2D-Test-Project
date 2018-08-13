using UnityEngine;

public class CharacterMovementView : MonoBehaviour
{

    public Animator Animator;
    private CharacterMovementModel _movementModel;
    public Transform WeaponParent;
    void Awake()
    {
        _movementModel = GetComponent<CharacterMovementModel>();
        if (Animator == null)
        {
            // check to see if we forgot to assign an animator reference
            Debug.Log("Animator not setup in CharacterMovementView");
            enabled = false;
        }
    }

    private void Start()
    {
        SetWeaponActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
        UpdatePickupAnimation();
        UpdateHit();
    }

    void UpdateHit()
    {
        Animator.SetBool("IsHit", _movementModel.IsPushed());
    }

    void UpdateDirection()
    {
        var direction = _movementModel.GetMovementDirection();
        if (direction != Vector3.zero)
        {
            Animator.SetFloat("DirectionX", direction.x);
            Animator.SetFloat("DirectionY", direction.y);
        }
        Animator.SetBool("IsMoving", _movementModel.IsMoving());
    }

    public void DoAttack()
    {
        Animator.SetTrigger("DoAttack");
    }

    public void OnAttackStarted()
    {
        SetWeaponActive(true);
    }

    public void OnAttackEnded()
    {
        SetWeaponActive(false);
    }

    void SetWeaponActive(bool activate)
    {
        if (WeaponParent != null)
            WeaponParent.gameObject.SetActive(activate);
        //for (int i = 0; i < WeaponParent.childCount; i++)
        //{
        //    Debug.Log("SETTING ACTIVATE WPN - " + activate);
        //    WeaponParent.GetChild(i).gameObject.GetComponentInChildren<Renderer>().enabled = activate;
        //}
    }

    void UpdatePickupAnimation()
    {
        bool isPickingUpOneHand = false;
        bool isPickingUpTwoHand = false;
        if (_movementModel.IsFrozen())
        {
            var pickedUpItemType = _movementModel.GetPickedUpItem();
            if (pickedUpItemType != ItemType.None)
            {
                var pickedUpItemData = Database.Items.FindItem(pickedUpItemType);
                if (pickedUpItemData.Animation == PickUpAnimation.OneHand)
                    isPickingUpOneHand = true;
                if (pickedUpItemData.Animation == PickUpAnimation.TwoHand)
                    isPickingUpTwoHand = true;
            }

        }
        Animator.SetBool("IsPickingUpOneHand", isPickingUpOneHand);
        Animator.SetBool("IsPickingUpTwoHand", isPickingUpTwoHand);

    }

    public void ShowWeapon()
    {
        SetWeaponActive(true);
    }

    public void HideWeapon()
    {
        SetWeaponActive(false);
    }

    public void SetSortingOrderOfWeapon(int sortingOrder)
    {
        if (WeaponParent != null)
        {
            SpriteRenderer[] renderers = WeaponParent.GetComponentsInChildren<SpriteRenderer>();
            if (renderers != null)
                foreach (var renderer in renderers)
                    renderer.sortingOrder = sortingOrder;
        }
    }
}
