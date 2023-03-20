using Assets.CodeBase.Plants;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Character
{
    public class RewardCollector : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _collectObserver;
        [SerializeField] private TriggerObserver _rewardObserver;
        [SerializeField] private int _stackLimit;
        [SerializeField] private Transform _startStackPoint;

        private List<PlantBrick> _bricks = new List<PlantBrick>();
        private Transform _lastConnected;

        public event Action<int, int> BrickCountChanged;

        private void OnEnable()
        {
            _collectObserver.TriggerEnter += OnCollectTriggerEnter;
            _rewardObserver.TriggerEnter += OnRewardTriggerEnter;
        }

        private void OnDisable()
        {
            _collectObserver.TriggerEnter -= OnCollectTriggerEnter;
            _rewardObserver.TriggerEnter -= OnRewardTriggerEnter;
        }

        private void Start()
        {
            BrickCountChanged?.Invoke(_bricks.Count, _stackLimit);
            _lastConnected = _startStackPoint;
        }

        private void OnRewardTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Shop shop))
                SellBricks(shop);
        }

        private void SellBricks(Shop shop)
        {
            StartCoroutine(SellBricksWithDelay(shop));
        }

        private void OnCollectTriggerEnter(Collider collider)
        {
            if (_bricks.Count < _stackLimit && collider.TryGetComponent(out PlantBrick brick))
            {
                brick.Take(_lastConnected);
                _lastConnected = brick.transform;
                _bricks.Add(brick);
                BrickCountChanged?.Invoke(_bricks.Count, _stackLimit);
            }
        }

        private IEnumerator SellBricksWithDelay(Shop shop)
        {
            for (int i = _bricks.Count - 1; i >= 0; i--)
            {
                shop.Sell(_bricks[i]);
                _bricks[i].Disconect();
                _bricks.Remove(_bricks[i]);
                BrickCountChanged?.Invoke(_bricks.Count, _stackLimit);

                yield return new WaitForSeconds(0.1f);
            }

            _lastConnected = _startStackPoint;
        }
    }
}
