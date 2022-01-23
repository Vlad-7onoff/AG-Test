using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private float _smoothTime;
    [SerializeField] private Vector3 _offset;

    private Transform _target;
    private Vector3 _velocity = Vector3.zero;

    public void Init(Transform playerTransform) {
        _target = playerTransform;
    }

    private void Update() {
        if (_target != null) {
            Vector3 targetPosition = _target.transform.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        }
    }
}
