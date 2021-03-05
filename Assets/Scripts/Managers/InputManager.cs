using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace Managers
{
    public class InputManager
    {
        private GameObject _rightHandController;
        private GameObject _leftHandController;
        private GameObject _headset;

        #region Singleton

        private static InputManager _instance;
        public static InputManager Instance => _instance ??= new InputManager();

        #endregion


        private ActionBasedController _controller;

        public bool IsTriggerPressed() => _controller.activateAction.action.ReadValue<bool>();
        public bool IsGripPressed() => _controller.selectAction.action.ReadValue<bool>();

        public void Initialize(GameObject leftHandController, GameObject rightHandController, GameObject headset)
        {
            this._leftHandController = leftHandController;
            this._rightHandController = rightHandController;
            this._headset = headset;
            
            
            _controller = _rightHandController.GetComponent<ActionBasedController>();
        }
    }
}