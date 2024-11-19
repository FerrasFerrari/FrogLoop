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
    private float hp = 1;
    [SerializeField]
    private GameObject explosionEffectGameObject;
    [SerializeField]
    [Tooltip("Layer Mask of the objects that can be hit by the explosion")]
    private LayerMask hittableObjectsMask;
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
    private void Explode(){
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explosionRadius, hittableObjectsMask);
        foreach (Collider2D hitObject in hitObjects){
            //IDamageable iDamageableScript = hitObject.gameObject.GetComponent<IDamageable>();
            //iDamageableScript?.Damage(explosionDamage, gameObject);
            hitObject.gameObject.GetComponent<IDamageable>()?.Damage(explosionDamage, gameObject);
        }
        Instantiate(explosionEffectGameObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Damage(float damageAmount, GameObject sender)
    {
        hp -= damageAmount;
        if(hp <= 0){
            Explode();
        }
    }
}
