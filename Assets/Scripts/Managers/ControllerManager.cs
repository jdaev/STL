using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace Managers
{
    public class ControllerManager
    {
        private GameObject _rightHandGameObject;
        private GameObject _leftHandGameObject;
        private GameObject _headset;

        private InputDevice _leftHandController;
        private InputDevice _rightHandController;
        #region Singleton

        private static ControllerManager _instance;
        public static ControllerManager Instance => _instance ??= new ControllerManager();

        #endregion


        private ActionBasedController _controller;

        public bool IsTriggerPressed() => _controller.activateAction.action.triggered;
        public bool IsGripPressed() => _controller.selectAction.action.triggered;

        public Vector2 ThumbstickAxis() => _controller.rotateAnchorAction.action.ReadValue<Vector2>();
        
        
        
        public void Initialize(GameObject leftHandController, GameObject rightHandController, GameObject headset)
        {
            this._leftHandGameObject = leftHandController;
            this._rightHandGameObject = rightHandController;
            this._headset = headset;
            
            List<InputDevice> inputDevices = new List<InputDevice>();
            InputDevices.GetDevices(inputDevices);
            foreach (var device in inputDevices)
            {
                if (device.characteristics == InputDeviceCharacteristics.Left)
                {
                    _leftHandController = device;
                }
                else if (device.characteristics == InputDeviceCharacteristics.Right)
                {
                    _rightHandController = device;
                }
            }
            _controller = _rightHandGameObject.GetComponent<ActionBasedController>();
            
        }
    }
}