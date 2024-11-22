using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    protected readonly int IdleAnimation = Animator.StringToHash("Idle");
    protected readonly int Attack1Animation = Animator.StringToHash("Attack1");
    protected readonly int Attack2Animation = Animator.StringToHash("Attack2");

    protected Animator animator;
    
    private void Awake()
    {
        TryGetComponent(out animator);
    }

    public void PlayIdleAnimation()
    {
        animator.Play(IdleAnimation);
    }

    public void PlayAttack1Animation()
    {
        animator.Play(Attack1Animation);
    }
    
    public void PlayAttack2Animation()
    {
        animator.Play(Attack2Animation);
    }
}
