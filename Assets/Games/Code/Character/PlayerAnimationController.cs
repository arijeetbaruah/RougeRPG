using System;
using System.Collections;
using UnityEngine;

namespace RougeRPG.Character
{
    public class PlayerAnimationController : MonoBehaviour
    {
        protected readonly int IdleAnimation = Animator.StringToHash("Idle");
        protected readonly int Attack1Animation = Animator.StringToHash("Attack1");
        protected readonly int Attack2Animation = Animator.StringToHash("Attack2");
        protected readonly int HitAnimation = Animator.StringToHash("Hit");

        protected Animator animator;
        protected Coroutine attackCoroutine;

        private void Awake()
        {
            TryGetComponent(out animator);
        }

        public void PlayIdleAnimation()
        {
            animator.Play(IdleAnimation);
        }

        public void PlayAttack1Animation(Action callback = null)
        {
            animator.Play(Attack1Animation);
            var animationState = animator.GetCurrentAnimatorStateInfo(0);
            attackCoroutine = StartCoroutine(Callback(animationState.length, callback));
        }

        public void PlayAttack2Animation(Action callback = null)
        {
            animator.Play(Attack2Animation);
            var animationState = animator.GetCurrentAnimatorStateInfo(0);
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = StartCoroutine(Callback(animationState.length, callback));
            }
        }

        public void PlayHitAnimation()
        {
            animator.Play(HitAnimation);
        }

        public IEnumerator Callback(float timer, Action callback)
        {
            yield return new WaitForSecondsRealtime(timer);
            callback?.Invoke();
            attackCoroutine = null;
        }
    }
}
