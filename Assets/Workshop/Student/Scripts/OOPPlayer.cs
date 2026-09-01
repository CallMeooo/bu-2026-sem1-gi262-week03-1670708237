using UnityEngine;
using UnityEngine.InputSystem;

public class OOPPlayer : Character
{


    private InputAction moveAction;

    public void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    public void Update()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();

        // call method Move(Vector2.up);
        if(moveAction.triggered)
        {
            Move(direction);
        }
    }
}
