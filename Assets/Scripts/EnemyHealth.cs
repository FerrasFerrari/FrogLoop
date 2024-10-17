using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{

    public float hp = 2;

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
    public void Damage(float damageAmount){
        TakeDamage(damageAmount);
    }
}
