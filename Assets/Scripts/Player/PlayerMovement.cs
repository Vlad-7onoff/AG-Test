using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 2f;
    [SerializeField] private float _minSidePos;
    [SerializeField] private float _maxSidePos;

    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private bool _isRun;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
    }

    private void OnEnable() {
        _input.RunButtonPressed += OnRunButtonPressed;
    }

    private void OnDisable() {
        _input.RunButtonPressed -= OnRunButtonPressed;
    }

    private void Update() {
        float clampedPositionX = Mathf.Clamp(transform.position.x, _minSidePos, _maxSidePos);
        transform.position = new Vector3(clampedPositionX, transform.position.y, transform.position.z);
    }

    private void FixedUpdate() {
        if (_isRun) {
            _rigidbody.velocity = Vector3.forward * _forwardSpeed;
            _rigidbody.velocity = new Vector3(_input.SideDirection, _rigidbody.velocity.y, _rigidbody.velocity.z);
        }
        else {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnRunButtonPressed(bool on) => _isRun = on;
}
