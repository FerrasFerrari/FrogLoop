using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private ParticleSystem damageParticleSystem;
    private Animator animator;
    public float hp = 2;
    


    private void Start() {
        damageParticleSystem = GetComponentInChildren<ParticleSystem>();
        animator = GetComponent<Animator>();
        
    }
    public void TakeDamage(float damage)
    {
        animator.SetTrigger("Damaged");
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        
    }
    public void Damage(float damageAmount, GameObject sender){
        if(damageParticleSystem != null){
            Vector2 direction = (transform.position - sender.gameObject.transform.position).normalized;
            damageParticleSystem.gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 45f);
            damageParticleSystem.Play();
        }

        TakeDamage(damageAmount);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Arrow"))
        {
            Die(); 
        }
    }
}
