using System;
using RougeRPG.Character;
using UnityEngine;

namespace RougeRPG
{
    [RequireComponent(typeof(Health))]
    public class CharacterAI : MonoBehaviour
    {
        [SerializeField] private HealthCanvas _healthCanvas;
        
        private Health _health;
        private PlayerAnimationController _playerAnim;

        private void Awake()
        {
            TryGetComponent(out _health);
            TryGetComponent(out _playerAnim);
        }

        private void OnEnable()
        {
            _health.onDamage += OnDamage;
            _health.onDeath += OnDeath;
        }

        private void OnDisable()
        {
            _health.onDamage -= OnDamage;
            _health.onDeath -= OnDeath;
        }

        private void OnDamage(Health character, float damage)
        {
            _playerAnim?.PlayHitAnimation();
            _healthCanvas.SetHeathBar(character, damage);
        }

        private void OnDeath(Health character)
        {
            _playerAnim.PlayDeathAnimation();
        }
    }
}
