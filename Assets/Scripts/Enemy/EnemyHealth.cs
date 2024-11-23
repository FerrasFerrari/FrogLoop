using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    //private ParticleSystem damageParticleSystem;
    public float hp = 2;
    private Animator animator;
    [SerializeField]private GameObject hitParticleEffectGameObject;
    public AudioSource audioSource;
    public AudioClip dano, morte;



    private void Start() {
        audioSource = GameObject.FindGameObjectWithTag("AudioSourceMosca").GetComponent<AudioSource>();
        //damageParticleSystem = GetComponentInChildren<ParticleSystem>();
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
        audioSource.clip = morte;
        audioSource.Play();
        Destroy(gameObject);
        
    }
    public void Damage(float damageAmount, GameObject sender){
        //if(damageParticleSystem != null){
            Vector2 direction = (transform.position - sender.gameObject.transform.position).normalized;
            //damageParticleSystem.gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 45f);
            //damageParticleSystem.Play();
        //}
        GameObject hitEffectInstance = Instantiate(hitParticleEffectGameObject, transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 45f));
        audioSource.clip = dano;
        audioSource.Play();
        TakeDamage(damageAmount);
        Destroy(hitEffectInstance, 1f);
    }
    
}
