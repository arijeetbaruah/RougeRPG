using System;
using RougeRPG.Character;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private PlayerAnimationController animator;
    [SerializeField] private AttackHitBox[] hitBoxes;

    private float timer = 0f;
    private float cooldown = 0f;

    private void Start()
    {
        foreach (var hitBox in hitBoxes)
        {
            hitBox.OnAttackHit += OnAttackHit;            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            return;
        }
        
        if (timer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                timer = 0.2f;
                cooldown = 0.5f;
                animator.PlayAttack1Animation();
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                timer = 0;
                cooldown = 0.5f;
                animator.PlayAttack2Animation();
            }
        }
    }

    private void OnAttackHit(Health target)
    {
        target.TakeDamage(10);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name + " " + other.gameObject.tag + " by " + gameObject.name);
    }
}
