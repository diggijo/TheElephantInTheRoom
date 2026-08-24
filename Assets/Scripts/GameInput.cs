using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private InputSystem inputSystems;

    private void Awake()
    {
        Instance = this;
        inputSystems = new InputSystem();
        inputSystems.Enable();
    }

    private void OnDestroy()
    {
        inputSystems.Disable();
    }

    public Vector2 GetMovementVector()
    {
        return inputSystems.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetLookVector()
    {
        return inputSystems.Player.Look.ReadValue<Vector2>();
    }

    public bool isJumpPressed()
    {
        return inputSystems.Player.Jump.triggered;
    }
    
}
