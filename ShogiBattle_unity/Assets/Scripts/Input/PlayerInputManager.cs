using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private IFlickable iFlickable;
    private Vector3 flickStartPos;
    private Vector3 flickEndPos;


    private void Awake()
    {
        inputActions = new InputSystem_Actions();

        iFlickable = GetComponent<IFlickable>();
    }

    private void OnEnable()
    {
        inputActions.Player.Flick.started += FlickStartInputReceiver;
        inputActions.Player.Flick.canceled += FlickEndInputReceiver;

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();

        inputActions.Player.Flick.started -= FlickStartInputReceiver;
        inputActions.Player.Flick.canceled -= FlickEndInputReceiver;
    }

    private void FlickStartInputReceiver(InputAction.CallbackContext context)
    {
        Pointer pointer = Pointer.current;
        flickStartPos = pointer.position.ReadValue();
    }

    private void FlickEndInputReceiver(InputAction.CallbackContext context)
    {
        Pointer pointer = Pointer.current;
        flickEndPos = pointer.position.ReadValue();

        CalcFlickDirection();
    }

    private void CalcFlickDirection()
    {
        var flickScreenDirection = (flickStartPos - flickEndPos).normalized;
        var flickDirection = new Vector3(flickScreenDirection.x, 0.0f, flickScreenDirection.y);
        iFlickable.FlickObject(flickDirection);
    }
}
