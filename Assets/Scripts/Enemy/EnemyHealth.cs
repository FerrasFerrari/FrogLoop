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
        HitStop.Instance.Stop(0.25f);
        audioSource.clip = morte;
        audioSource.Play();
        StartCoroutine(WaitForTimescale());
        
    }
    public void Damage(float damageAmount, GameObject sender){
        GetComponent<DamageFlash>().CallDamageFlasher();
        HitStop.Instance.Stop(0.15f);
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
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<IDamageable>().Damage(1, gameObject);
        }
    }

    IEnumerator WaitForTimescale(){
        while(Time.timeScale != 1f)
            yield return null;
        Destroy(gameObject);
    }
    
}
