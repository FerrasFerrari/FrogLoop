using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour, IDamageable
{
    public float hp = 1f;
    [SerializeField]private GameObject breakParticlesPrefab;

    public AudioSource audioSource;
    public AudioClip quebrar;

    public void Damage(float damageAmount, GameObject sender)
    {
        GetComponent<DamageFlash>().CallDamageFlasher();
        hp -= damageAmount;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject particleSystem = Instantiate(breakParticlesPrefab, transform.position, Quaternion.identity);
        audioSource.clip = quebrar;
        audioSource.Play(); 
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
