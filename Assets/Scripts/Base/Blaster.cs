using Managers;
using UnityEngine;

namespace Base
{
    public class Blaster : MonoBehaviour
    {
        [SerializeField] private GameObject nozzle;
        [SerializeField] private GameObject colorIndicator;
        [SerializeField] private Controller controller;
        private int _activeColorIndex = 0;
        private float _range = 100f;
        private float _blasterRadius = 1f;
        private STLColor[] _colors = new[] {STLColor.Red, STLColor.Blue, STLColor.Green};


        private Material _colorIndicatorMaterial;

        public void Initialize()
        {
            _colorIndicatorMaterial = colorIndicator.GetComponent<MeshRenderer>().material;
            if (controller == Controller.Right)
            {
                _activeColorIndex = 1;
            }

            SetIndicatorColor();
        }
        

        public void Refresh()
        {
            if (controller == Controller.Right)
            {
                if (ControllerManager.Instance.IsRightGripPressed() &&
                    ControllerManager.Instance.RightThumbstickAxis().x < 0 || Input.GetKeyDown(KeyCode.Q))
                {
                    SwitchColor(-1);
                }

                if (ControllerManager.Instance.IsRightGripPressed() &&
                    ControllerManager.Instance.RightThumbstickAxis().x > 0 || Input.GetKeyDown(KeyCode.W))
                {
                    SwitchColor(1);
                }

                if (Input.GetKeyDown(KeyCode.S) || ControllerManager.Instance.IsRightTriggerPressed())
                {
                    Fire();
                }
            }
            else
            {
                if (ControllerManager.Instance.IsLeftGripPressed() &&
                    ControllerManager.Instance.LeftThumbstickAxis().x < 0 || Input.GetKeyDown(KeyCode.Q))
                {
                    SwitchColor(-1);
                }

                if (ControllerManager.Instance.IsLeftGripPressed() &&
                    ControllerManager.Instance.LeftThumbstickAxis().x > 0 || Input.GetKeyDown(KeyCode.W))
                {
                    SwitchColor(1);
                }

                if (Input.GetKeyDown(KeyCode.S) || ControllerManager.Instance.IsLeftTriggerPressed())
                {
                    Fire();
                }
            }
        }

        private void Fire()
        {
            RaycastHit raycastHit;
            bool hasHit = Physics.SphereCast(nozzle.transform.position, _blasterRadius, nozzle.transform.forward,
                out raycastHit, _range);
            if (hasHit)
            {
                var enemy = raycastHit.transform.gameObject.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.OnBulletHit(_colors[_activeColorIndex]);
                }
            }
            GameManager.Instance.AudioManager.PlayFireSound();
            GameManager.Instance.LaserManager.ShootLaser(_colors[_activeColorIndex], nozzle.transform,
                hasHit ? raycastHit.point : nozzle.transform.position+  ( transform.forward*_range));
        }


        private void SwitchColor(int axis)
        {
            if (axis < 0)
            {
                _activeColorIndex = _activeColorIndex == 0 ? _colors.Length - 1 : _activeColorIndex - 1;
            }
            else
            {
                _activeColorIndex = _activeColorIndex == (_colors.Length - 1) ? 0 : _activeColorIndex + 1;
            }

            SetIndicatorColor();
        }

        private void SetIndicatorColor()
        {
            _colorIndicatorMaterial.color = Values.ColorMap[_colors[_activeColorIndex]];
            _colorIndicatorMaterial.SetColor("_EmissionColor", Values.ColorMap[_colors[_activeColorIndex]]);
        }
    }

    public enum Controller
    {
        Left,
        Right
    }
}