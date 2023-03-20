using DG.Tweening;
using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _moneyAmount;

    public event Action<int, Coin> TargetAchieved;

    public void Construct(int amount, RectTransform target)
    {
        _moneyAmount = amount;

        Sequence moveToTarget = DOTween.Sequence();

        moveToTarget.Join(transform.DOMove(target.position, 1))
            .AppendCallback(OnTargetAchieved);
    }

    private void OnTargetAchieved()
    {
        TargetAchieved?.Invoke(_moneyAmount, this);
    }
}
