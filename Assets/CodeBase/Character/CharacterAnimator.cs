using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int IsMoving = Animator.StringToHash("IsMoving");
    private readonly int MovingHash = Animator.StringToHash("Mowing");

    public void SetMove(bool isMoving)
    {
        _animator.SetBool(IsMoving, isMoving);
    }
}
