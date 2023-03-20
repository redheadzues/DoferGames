using Assets.CodeBase.Plants;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Transform _moveBrickPoint;
    [SerializeField] private PlayerRewarder _playerRewarder;

    public void Sell(PlantBrick brick)
    {
        brick.transform.DOMove(_moveBrickPoint.position, 1);

        _playerRewarder.Reward(brick.Price, _moveBrickPoint.position);
    }

}
