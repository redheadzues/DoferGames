using System;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _isMovingHash = Animator.StringToHash("IsMoving");
    private readonly int _harvestHash = Animator.StringToHash("Harvest");

    public void SetMove(bool isMoving) => 
        _animator.SetBool(_isMovingHash, isMoving);

    public void Harvest() => 
        _animator.SetTrigger(_harvestHash);
}
