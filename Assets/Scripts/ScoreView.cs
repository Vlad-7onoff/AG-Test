using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;

    public void Init(Player player) {
        player.Wallet.AmountChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score) {
        _view.text = score.ToString();
    }
}
