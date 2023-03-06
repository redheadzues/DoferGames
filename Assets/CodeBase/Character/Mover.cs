using UnityEngine;

namespace Assets.CodeBase.Character
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private DynamicJoystick _joystick;
        [SerializeField] private float _speed;
        [SerializeField] private CharacterController _charatcterController;
        [SerializeField] private CharacterAnimator _characterAnimator;


        private void Update()
        {
            Vector3 direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

            if (direction.magnitude != 0)
                Move(direction);
            else
                _characterAnimator.SetMove(false);
        }

        private void Move(Vector3 direction)
        {
            _charatcterController.Move(direction * _speed * Time.deltaTime);
            transform.LookAt(transform.position + direction);
            _characterAnimator.SetMove(true);
        }
    }
}
