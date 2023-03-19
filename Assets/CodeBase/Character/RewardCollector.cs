using Assets.CodeBase.Plants;
using UnityEngine;

namespace Assets.CodeBase.Character
{
    public class RewardCollector : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _collectObserver;
        [SerializeField] private Rigidbody _connectingBody;
        [SerializeField] private int _stackLimit;

        private Rigidbody _lastConnected;
        private int _currentStack;

        private void OnEnable()
        {
            _collectObserver.TriggerEnter += OnCollectTriggerEnter;
        }

        private void Start()
        {
            _lastConnected = _connectingBody;
        }

        private void OnDisable()
        {
            _collectObserver.TriggerEnter -= OnCollectTriggerEnter;
        }

        private void OnCollectTriggerEnter(Collider collider)
        {
            if (_currentStack < _stackLimit && collider.TryGetComponent(out PlantBrick brick))
            {
                brick.Take(_lastConnected);
                _lastConnected = brick.Rigidbody;
                _currentStack++;
                print(_currentStack);
            }
        }
    }
}
