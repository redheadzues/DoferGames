using DG.Tweening;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class PlantBrick : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Collider _collider;

        private int _price;
        private Transform _followingBrick;
        private Vector3 _baseScale;
        private bool _isFollowingAllow;
        public int Price => _price;

        public void Construct(int price)
        {
            _price = price;
            Appear();
            _baseScale = transform.localScale;
        }

        private void LateUpdate()
        {
            if (_isFollowingAllow)
            {
                transform.position = new Vector3(
                    Mathf.Lerp(transform.position.x, _followingBrick.position.x, _speed * Time.deltaTime),
                    transform.position.y,
                    Mathf.Lerp(transform.position.z, _followingBrick.position.z, _speed * Time.deltaTime));

                transform.rotation = _followingBrick.rotation;
            }
        }

        public void Take(Transform followingBrick)
        {
            _collider.enabled = false;
            _followingBrick = followingBrick;

            transform.SetParent(followingBrick.transform);

            transform.DOLocalJump(Vector3.zero + Vector3.up * 0.3f, 5, 1, 1).OnComplete(FinishAddinStack);
        }

        public void Disconect()
        {
            _isFollowingAllow = false;
            _followingBrick = null;
        }

        public void FinishAddinStack()
        {
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.SetParent(null);
            transform.localScale = _baseScale;
            _isFollowingAllow = true;
            
        }

        private void Appear()
        {
            Vector2 randomPoint = Random.insideUnitCircle * 3;
            Vector3 jumpPoint = new Vector3(transform.position.x + randomPoint.x, transform.position.y, transform.position.z + randomPoint.y);
            
            transform.DOJump(jumpPoint, 2, 1, 0.7f);
        }
    }
}
