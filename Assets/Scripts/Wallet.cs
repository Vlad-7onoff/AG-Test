using System;
using System.Collections;
using System.Collections.Generic;

public class Wallet
{
    private int _amount = 0;

    public Action<int> AmountChanged;

    public void AddScore(int coinPrice) {
        _amount += coinPrice;
        AmountChanged?.Invoke(_amount);
    }
}
