using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _runButton = KeyCode.Mouse0;

    private float _positionX;
    private float _sideDirection;

    public float SideDirection => _sideDirection;
    public Action<bool> RunButtonPressed;

    private void Update() {
        if (Input.GetKeyDown(_runButton)) {
            _positionX = Input.mousePosition.x;
            RunButtonPressed?.Invoke(true);
        }
        else if (Input.GetKey(_runButton)) {
            _sideDirection = Input.mousePosition.x - _positionX;
            _positionX = Input.mousePosition.x;
        }
        else if (Input.GetKeyUp(_runButton)) {
            RunButtonPressed?.Invoke(false);
        }
    }

    public void DisableInput() {
        RunButtonPressed?.Invoke(false);
        enabled = false;
    }
}
