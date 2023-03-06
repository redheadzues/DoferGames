using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _charatcterController;

    private void Update()
    {
        Vector3 direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        _charatcterController.Move(direction * _speed * Time.deltaTime);
    }
}
