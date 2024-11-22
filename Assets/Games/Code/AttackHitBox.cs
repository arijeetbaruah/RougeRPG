using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    public delegate void OnAttackHitDelegate(Health target);

    public OnAttackHitDelegate OnAttackHit;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != transform.parent.gameObject && other.gameObject.TryGetComponent<Health>(out Health health))
        {
            OnAttackHit?.Invoke(health);
        }
    }
}
