using UnityEngine;
using UnityEngine.InputSystem;

public class OOPPlayer : MonoBehaviour
{
    public string Name;
    public int positionX;
    public int positionY;
    public OOPMapGenerator mapGenerator;

    private InputAction moveAction;

    public void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    public void Update()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();

        // call method Move(Vector2.up);
        
    }
}
