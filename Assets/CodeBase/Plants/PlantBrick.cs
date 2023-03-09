using DG.Tweening;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class PlantBrick : MonoBehaviour
    {
        private HingeJoint _joint;

        private int _price;
        public int Price => _price;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
                Appear();
        }

        public void Construct(int price)
        {
            _price = price;
            Appear();
        }

        public void ConnectJoint(Rigidbody connectedBody)
        {
            _joint = gameObject.AddComponent<HingeJoint>();
            
            SetupJoint();
            _joint.connectedBody = connectedBody;
        }

        public void DisconnectJoint()
        {
            _joint.connectedBody = null;
            Component.Destroy(_joint);
        }

        private void Appear()
        {
            Vector2 randomPoint = Random.insideUnitCircle * 2;
            Vector3 jumpPoint = new Vector3(transform.position.x + randomPoint.x, transform.position.y, transform.position.z + randomPoint.y);
            
            transform.DOJump(jumpPoint, 2, 1, 0.7f);
        }

        private void SetupJoint()
        {         
            _joint.massScale = 2.5f;
            _joint.useSpring = true;
            JointSpring springSetting = _joint.spring;
            springSetting.spring = 1000f;
            springSetting.damper = 100;
            _joint.spring = springSetting;
        }
    }
}
