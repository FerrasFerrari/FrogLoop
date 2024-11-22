using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float explosionRadius = 1.6f;
    [SerializeField]
    private int explosionDamage = 3;
    [SerializeField]
    private float explosionKnockbackMultiplier = 13f;
    [SerializeField]
    private float hp = 1;
    [SerializeField]
    private float explosionDelay;
    [SerializeField]
    private GameObject explosionEffectGameObject;
    [SerializeField]
    [Tooltip("Layer Mask of the objects that can be hit by the explosion")]
    private LayerMask hittableObjectsMask;
    public AudioSource audioSource;
    public AudioClip explosao;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    private IEnumerator Explode(){
        List<int> hittedInstanceID = new();
        Instantiate(explosionEffectGameObject, transform.position, Quaternion.identity);
        audioSource.clip = explosao;
        audioSource.Play();
        yield return new WaitForSeconds(explosionDelay);
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explosionRadius, hittableObjectsMask);
        foreach (Collider2D hitObject in hitObjects){
            if(!hittedInstanceID.Contains(hitObject.gameObject.GetInstanceID())) { 
                hittedInstanceID.Add(hitObject.gameObject.GetInstanceID());
                GameObject hitGameObject = hitObject.gameObject;
                    //if(!hitObject.gameObject.GetComponent<PlayerHealth>().isOnImmunity){
                        hitGameObject.GetComponent<IDamageable>()?.Damage(explosionDamage, gameObject);
                        hitGameObject.GetComponent<Knockbacker>()?.Knockback(explosionKnockbackMultiplier, gameObject);
                    //}
            }
        }
        Destroy(gameObject);
    }

    public void Damage(float damageAmount, GameObject sender)
    {
        hp -= damageAmount;
        if(hp <= 0){
            StartCoroutine(Explode());
        }
    }
}
