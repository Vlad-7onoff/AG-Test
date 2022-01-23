using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Action Finished;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Player player)) {
            player.Finish();
            Finished?.Invoke();
        }
    }
}
