using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour, IDamageable
{
    public float hp = 1f;
    [SerializeField]private GameObject breakParticlesPrefab;

    public void Damage(float damageAmount, GameObject sender)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject particleSystem = Instantiate(breakParticlesPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(particleSystem, 1);
    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
