using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using InputDevice = UnityEngine.InputSystem.InputDevice;

namespace Managers
{
    public class ControllerManager
    {
        private GameObject _rightHandGameObject;
        private GameObject _leftHandGameObject;
        private GameObject _headset;

        #region Singleton

        private static ControllerManager _instance;
        public static ControllerManager Instance => _instance ??= new ControllerManager();

        #endregion


        private ActionBasedController _rightHandController;
        private ActionBasedController _leftHandController;

        public bool IsRightTriggerPressed() => _rightHandController.activateAction.action.triggered;
        public bool IsRightGripPressed() => _rightHandController.selectAction.action.triggered;
        
        public Vector2 RightThumbstickAxis() => _rightHandController.rotateAnchorAction.action.ReadValue<Vector2>();
        
        public bool IsLeftTriggerPressed() => _leftHandController.activateAction.action.triggered;
        public bool IsLeftGripPressed() => _leftHandController.selectAction.action.triggered;
        
        public Vector2 LeftThumbstickAxis() => _leftHandController.rotateAnchorAction.action.ReadValue<Vector2>();


        public void Initialize(GameObject leftHandController, GameObject rightHandController, GameObject headset)
        {
            this._leftHandGameObject = leftHandController;
            this._rightHandGameObject = rightHandController;
            this._headset = headset;

            _rightHandController = _rightHandGameObject.GetComponent<ActionBasedController>();
            _leftHandController = _leftHandGameObject.GetComponent<ActionBasedController>();
        }
    }
}