using DG.Tweening;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class PlantBrick : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private HingeJoint _joint;
        [SerializeField] private Collider _collider;

        private int _price;
        private Rigidbody _connectingBody;
        private Vector3 _baseScale;
        public int Price => _price;
        public Rigidbody Rigidbody => _rigidbody;

        public void Construct(int price)
        {
            _price = price;
            DisconnectJoint();
            Appear();
            _baseScale = transform.localScale;
        }

        public void Take(Rigidbody connectedBody)
        {
            _connectingBody = connectedBody;
            _collider.enabled = false;

            transform.SetParent(connectedBody.transform);

            var jumpSequence = DOTween.Sequence();

            jumpSequence
                .Join(transform.DOLocalJump(Vector3.zero, 5, 1, 1))
                .AppendCallback(ConnectJoint);
        }

        public void ConnectJoint()
        {
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.SetParent(null);
            transform.localScale = _baseScale;

            _rigidbody.isKinematic = false;
            _joint.connectedBody = _connectingBody;
        }

        public void DisconnectJoint()
        {
            _rigidbody.isKinematic = true;
            _joint.connectedBody = null;
        }

        private void Appear()
        {
            Vector2 randomPoint = Random.insideUnitCircle * 3;
            Vector3 jumpPoint = new Vector3(transform.position.x + randomPoint.x, transform.position.y, transform.position.z + randomPoint.y);
            
            transform.DOJump(jumpPoint, 2, 1, 0.7f);
        }
    }
}
