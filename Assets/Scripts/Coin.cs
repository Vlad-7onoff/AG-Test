using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _cost = 1;
    [SerializeField] private ParticleSystem _destroyEffect;

    public int Cost => _cost;

    private void OnDestroy() {
        if (gameObject.scene.isLoaded)
            Instantiate(_destroyEffect, transform.position, Quaternion.identity);
    }

    public int Collect() {
        Destroy(gameObject);
        return _cost;
    }
}
