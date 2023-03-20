using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _money;

    public event Action<int> BalanceChanged;

    public void AddMoney(int count)
    {
        _money += count;
        BalanceChanged?.Invoke(_money);
    }
}
