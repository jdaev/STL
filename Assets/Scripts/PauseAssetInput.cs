using UnityEngine;
using UnityEngine.InputSystem;

public class PauseAssetInput : MonoBehaviour
{
    public bool printStuff = true;
    public InputActionReference pauseReference = null;

    private void Start()
    {
        pauseReference.action.started += DoPressedThing;
        pauseReference.action.performed += DoChangeThing;
        pauseReference.action.canceled += DoReleasedThing;
    }

    private void OnEnable()
    {
        pauseReference.asset.Enable();
    }

    private void OnDisable()
    {
        pauseReference.asset.Disable();
    }

    private void OnDestroy()
    {
        pauseReference.action.started -= DoPressedThing;
        pauseReference.action.performed -= DoChangeThing;
        pauseReference.action.canceled -= DoReleasedThing;
    }

    private void DoPressedThing(InputAction.CallbackContext context)
    {
        if (printStuff)
            print("Pressed");
    }

    private void DoChangeThing(InputAction.CallbackContext context)
    {
        if (printStuff)
            print(context.ReadValue<float>());
    }

    private void DoReleasedThing(InputAction.CallbackContext context)
    {
        if (printStuff)
            print("Released");
    }
}