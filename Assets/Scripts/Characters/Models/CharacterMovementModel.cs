using System.Collections;
using UnityEngine;

public class CharacterMovementModel : MonoBehaviour {

    public float Speed;

    private Vector3 _movementDirection;
    private Vector3 _facingDirection;
    public Rigidbody2D body;
    private bool _isFrozen;
    private bool _isAttacking;
    private ItemType _equippedWeapon = ItemType.None;
    public Transform WeaponParent;
    public Transform ShieldParent;
    public Transform PickUpItemParent;
    private ItemType _pickedUpItemType = ItemType.None;
    private GameObject _pickedUpObject;
    private Vector2 _pushDirection;
    private float _pushTime;


	void Awake () {
        body = GetComponent<Rigidbody2D>();
	}

    private void Start()
    {
        _isAttacking = false;
        _isFrozen = false;
    }

    private void Update()
    {
        UpdatePushTime();
    }

    //use fixedupdate when working with physics
    void FixedUpdate () {
        UpdateMovement();
	}

    void UpdatePushTime()
    {
        _pushTime = Mathf.MoveTowards(_pushTime, 0f, Time.deltaTime);
    }

    public void SetFrozen(bool isFrozen, bool freezeTime)
    {
        _isFrozen = isFrozen;
        if (freezeTime)
        {
            if (isFrozen)
            {
                StartCoroutine(FreezeTimeRouting());
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        //UpdateMovement();
    }

    IEnumerator FreezeTimeRouting()
    {
        yield return null;
        Time.timeScale = 0f;
    }

    void UpdateMovement()
    {
        if (IsPushed())
        {
            body.velocity = _pushDirection;
        }
        else
        {
            if (_isFrozen || _isAttacking)
            {
                body.velocity = Vector2.zero;
                return;
            }
            if (_movementDirection != Vector3.zero)
                _movementDirection.Normalize();

            body.velocity = _movementDirection * Speed;
        }
    }

    public void SetDirection(Vector2 direction)
    {
        if (IsPushed())
        {
            _facingDirection = _pushDirection;
            return;
        }
        if (direction != Vector2.zero && GetPickedUpItem() != ItemType.None) {
            _pickedUpItemType = ItemType.None;
            SetFrozen(false, true);
            Destroy(_pickedUpObject);
        }
        if (_isFrozen || _isAttacking)
        {
            return;
        }
        _movementDirection = new Vector3(direction.x, direction.y, 0);
        if (direction != Vector2.zero)
            _facingDirection = _movementDirection;
    }

    public Vector3 GetMovementDirection()
    {
        return _movementDirection;
    }

    public Vector3 GetFacingDirection()
    {
        return _facingDirection;
    }

    public bool IsMoving()
    {
        if (!_isFrozen)
            return _movementDirection != Vector3.zero;
        return false;
    }

    public bool CanAttack()
    {
        Debug.Log("canAttack? - " + _isAttacking);
        if (_equippedWeapon == ItemType.None)
        return false;
        return !_isAttacking;
    }

    public void DoAttack()
    {
    }

    public void OnAttackStarted()
    {
        _isAttacking = true;
        Debug.Log("attack start");
    }

    public void OnAttackEnded()
    {
        _isAttacking = false;
        Debug.Log("attack end");
    }

    public void EquipItem(ItemType weapon)
    {
        if (WeaponParent == null) return;
        var item = Database.Items.FindItem(weapon);
        if (item != null && item.EquipmentSlot != ItemData.EquipSlot.None)
        {
            GameObject sword = Instantiate(item.Prefab);
            if (item.EquipmentSlot == ItemData.EquipSlot.MainHand)
            {
                _equippedWeapon = weapon;
                sword.transform.parent = WeaponParent;
            }
            if (item.EquipmentSlot == ItemData.EquipSlot.OffHand)
                sword.transform.parent = ShieldParent;
            sword.transform.localPosition = Vector2.zero;
            sword.transform.localRotation = Quaternion.identity;
        }
        
    }

    public void ShowItemPickup(ItemType type)
    {
        if (PickUpItemParent == null) return;
        var item = Database.Items.FindItem(type);
        SetFrozen(true, true);
        _pickedUpItemType = type;
        _pickedUpObject = Instantiate(item.Prefab);
        _pickedUpObject.transform.parent = PickUpItemParent;
        _pickedUpObject.transform.localPosition = Vector2.zero;
        _pickedUpObject.transform.localRotation = Quaternion.identity;
    }

    public bool IsFrozen() { return _isFrozen; }

    public ItemType GetPickedUpItem()
    {
        return _pickedUpItemType;
    }

    public bool IsPushed()
    {
        return _pushTime > 0;
    }

    public void PushCharacter(Vector2 direction, float time)
    {
        _pushTime = time;
        _pushDirection = direction;
    }
}
