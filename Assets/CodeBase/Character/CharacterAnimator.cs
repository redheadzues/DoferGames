using System;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _isMovingHash = Animator.StringToHash("IsMoving");
    private readonly int _harvestHash = Animator.StringToHash("Harvest");

    public event Action MoveStarted;

    public void SetMove(bool isMoving)
    {
        _animator.SetBool(_isMovingHash, isMoving);

        if (isMoving == true)
            MoveStarted?.Invoke();
    }

    public void Harvest() => 
        _animator.SetTrigger(_harvestHash);
}
