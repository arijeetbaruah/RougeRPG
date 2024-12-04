using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;

    public delegate void OnDeathDelegate(Health character);
    public delegate void OnDamageDelegate(Health character, float damage);
    
    public OnDeathDelegate onDeath;
    public OnDamageDelegate onDamage;
    
    public int CurrentHealth => health;
    public int MaxHealth => maxHealth;

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
    }
    
    public void TakeDamage(int damage)
    {
        if (health <= 0)
            return;
        
        health = Mathf.Max(health - damage, 0);
        onDamage?.Invoke(this, damage);
        if (health == 0)
        {
            onDeath?.Invoke(this);
        }
    }
}
