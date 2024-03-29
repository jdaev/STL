using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace Managers
{
    public class ControllerManager
    {
        private GameObject _rightHandGameObject;
        private GameObject _leftHandGameObject;

        #region Singleton

        private static ControllerManager _instance;
        public static ControllerManager Instance => _instance ??= new ControllerManager();

        #endregion


        private ActionBasedController _rightHandController;
        private ActionBasedController _leftHandController;

        public InputActionReference PauseInputAction;

        public bool IsRightTriggerPressed() => _rightHandController.activateAction.action.triggered;
        public bool IsRightGripPressed() => _rightHandController.selectAction.action.triggered;

        public Vector2 RightThumbstickAxis() => _rightHandController.rotateAnchorAction.action.ReadValue<Vector2>();

        public bool IsLeftTriggerPressed() => _leftHandController.activateAction.action.triggered;
        public bool IsLeftGripPressed() => _leftHandController.selectAction.action.triggered;


        public Vector2 LeftThumbstickAxis() => _leftHandController.rotateAnchorAction.action.ReadValue<Vector2>();


        public void Initialize(GameObject leftHandController, GameObject rightHandController,
            InputActionReference pauseInputAction)
        {
            _leftHandGameObject = leftHandController;
            _rightHandGameObject = rightHandController;

            _rightHandController = _rightHandGameObject.GetComponent<ActionBasedController>();
            _leftHandController = _leftHandGameObject.GetComponent<ActionBasedController>();

            PauseInputAction = pauseInputAction;
            PauseInputAction.asset.Enable();
        }

        public void ToggleInteractors(bool toggle)
        {
            ToggleLeftHandInteractors(toggle);
            ToggleRightHandInteractors(toggle);
        }

        private void ToggleLeftHandInteractors(bool toggle)
        {
            XRRayInteractor xrRayInteractor = _leftHandGameObject.GetComponent<XRRayInteractor>();
            LineRenderer lineRenderer = _leftHandGameObject.GetComponent<LineRenderer>();
            XRInteractorLineVisual xrInteractorLineVisual = _leftHandController.GetComponent<XRInteractorLineVisual>();

            xrRayInteractor.enabled = toggle;
            lineRenderer.enabled = toggle;
            xrInteractorLineVisual.enabled = toggle;
        }

        private void ToggleRightHandInteractors(bool toggle)
        {
            XRRayInteractor xrRayInteractor = _rightHandGameObject.GetComponent<XRRayInteractor>();
            LineRenderer lineRenderer = _rightHandGameObject.GetComponent<LineRenderer>();
            XRInteractorLineVisual xrInteractorLineVisual = _rightHandController.GetComponent<XRInteractorLineVisual>();

            xrRayInteractor.enabled = toggle;
            lineRenderer.enabled = toggle;
            xrInteractorLineVisual.enabled = toggle;
        }
    }
}