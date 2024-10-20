using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private ParticleSystem damageParticleSystem;
    public float hp = 2;


    private void Awake() {
        damageParticleSystem = GetComponentInChildren<ParticleSystem>();
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    public void Damage(float damageAmount, float aimAngle, GameObject sender){
        if(damageParticleSystem != null){
            damageParticleSystem.gameObject.transform.rotation = Quaternion.Euler(0, 0, aimAngle - 45);
            damageParticleSystem.Play();
        }

        TakeDamage(damageAmount);
    }
}
