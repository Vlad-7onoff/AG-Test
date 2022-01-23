using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _input;

    private const string RunParameter = "IsRun";

    private void Awake() {
        _animator = GetComponent<Animator>();
        _input = GetComponent<PlayerInput>();
    }

    private void OnEnable() {
        _input.RunButtonPressed += OnRunning;
    }

    private void OnDisable() {
        _input.RunButtonPressed -= OnRunning;
    }

    private void OnRunning(bool isRun) {
        _animator.SetBool(RunParameter, isRun);
    }
}
