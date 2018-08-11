using UnityEngine;

public class CharacterKeyboardControl : CharacterBaseControl {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDirection();
        UpdateAction();
        UpdateAttack();
	}

    void UpdateAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnActionPressed();
        }
    }

    void UpdateAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnAttackPressed();
        }
    }

    void UpdateDirection()
    {
        var newDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            newDirection.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newDirection.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newDirection.x = 1;
        }
        SetDirection(newDirection);
    }
}
