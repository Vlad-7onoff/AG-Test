using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private PlayerTracker _playerTracker;
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private Player _playerPrefab;

    private void Awake() {
        var player = Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity);
        _playerTracker.Init(player.transform);
        _scoreView.Init(player);
    }
}
