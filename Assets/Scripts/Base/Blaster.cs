using System.Collections;
using System.Collections.Generic;
using Base;
using Managers;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] private GameObject nozzle;
    [SerializeField] private GameObject colorIndicator;

    private int _activeColorIndex = 0;
    private STLColor[] _colors = new[] {STLColor.Red, STLColor.Blue, STLColor.Green};

    private bool _isFiring;

    private Material _colorIndicatorMaterial;

    public void Initialize()
    {
        _colorIndicatorMaterial = colorIndicator.GetComponent<MeshRenderer>().material;
        SetIndicatorColor();
    }

    public void Refresh()
    {
        if (InputManager.Instance.ThumbstickAxis().x < 0 || Input.GetKeyDown(KeyCode.Q))
        {
            SwitchColor(-1);
        }

        if (InputManager.Instance.ThumbstickAxis().x > 0 || Input.GetKeyDown(KeyCode.W))
        {
            SwitchColor(1);
        }

        if (Input.GetKeyDown(KeyCode.S) || InputManager.Instance.IsTriggerPressed())
        {
            Fire();
        }
    }

    private void Fire()
    {
        

        BulletManager.Instance.ShootBullet(_colors[_activeColorIndex], nozzle.transform);
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
    }
}