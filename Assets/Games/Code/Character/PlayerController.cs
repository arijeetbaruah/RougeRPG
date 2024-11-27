using System;
using RougeRPG.Input;
using RougeRPG.Service;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RougeRPG.Character
{
    [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(Health))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private AttackHitBox[] hitBoxes;
        [SerializeField] private float movementSpeed;
        
        private PlayerAnimationController _animatoAnimationController;
        private Health _health;
        private float _xMovement;
        private float _timer = 0f;
        private float _cooldown = 0f;
        private bool _isAttacking = false;

        private InputService InputService => ServiceManager.Get<InputService>();
        
        private void Awake()
        {
            TryGetComponent(out _animatoAnimationController);
            TryGetComponent(out _health);
        }

        private void OnEnable()
        {
            foreach (var hitBox in hitBoxes)
            {
                hitBox.OnAttackHit += OnAttackHit;            
            }

            InputService.Player.Movement.performed += OnMovement;
            InputService.Player.Attack.performed += OnAttack;
            InputService.Player.Enable();
            _health.onDamage += OnDamage;
        }

        private void OnDisable()
        {
            foreach (var hitBox in hitBoxes)
            {
                hitBox.OnAttackHit -= OnAttackHit;            
            }

            if (ServiceManager.HasInstance)
            {
                InputService.Player.Disable();
                InputService.Player.Movement.performed -= OnMovement;
                InputService.Player.Attack.performed -= OnAttack;
            }
            _health.onDamage -= OnDamage;
        }

        private void Update()
        {
            HandleMovement();
            HandleAttackCooldown();
        }

        private void OnDamage(Health character, float damage)
        {
            _animatoAnimationController.PlayHitAnimation();
        }

        private void HandleAttackCooldown()
        {
            if (_cooldown > 0)
            {
                _cooldown -= Time.deltaTime;
                return;
            }
            
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
        }

        private void HandleMovement()
        {
            if (_xMovement != 0 && !_isAttacking)
            {
                Vector3 scale = transform.localScale;
                scale.x = _xMovement * scale.y;
                transform.localScale = scale;
                transform.position += transform.right * _xMovement * movementSpeed * Time.deltaTime;
            }
        }

        private void OnMovement(InputAction.CallbackContext obj)
        {
            float axis = obj.ReadValue<float>();
            _xMovement = axis;
        }

        private void OnAttack(InputAction.CallbackContext obj)
        {
            _isAttacking = true;
            if (_timer <= 0)
            {
                _animatoAnimationController.PlayAttack1Animation(() => _isAttacking = false);
                _timer = 0.2f;
                _cooldown = 0.5f;
            }
            else
            {
                _timer = 0;
                _cooldown = 0.5f;
                _animatoAnimationController.PlayAttack2Animation(() => _isAttacking = false);
            }
        }
        
        private void OnAttackHit(Health target)
        {
            target.TakeDamage(10);
        }
    }
}
