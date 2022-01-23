using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    public Wallet Wallet => _wallet;

    private Wallet _wallet;
    private PlayerInput _playerInput;
     
    private void Awake() {
        _wallet = new Wallet();
        _playerInput = GetComponent<PlayerInput>();

    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Coin coin)) {
            _wallet.AddScore(coin.Collect());
        }
    }

    public void Finish() {
        _playerInput.DisableInput();
    }
}
