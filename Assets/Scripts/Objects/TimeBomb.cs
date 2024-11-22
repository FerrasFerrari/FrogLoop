using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float explosionRadius = 1.6f;
    [SerializeField]
    private int explosionDamage = 3;
    [SerializeField]
    private float hp = 1;
    [SerializeField]
    [Tooltip("Layer Mask of the objects that can be hit by the explosion")]
    private LayerMask hittableObjectsMask;
    public AudioSource audioSource;
    public AudioClip explosao;

    public bool NSM;
    void Start()
    {
        NSM = false;
    }

    void Update()
    {

    }
    private void SlowMotion()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explosionRadius, hittableObjectsMask);
        foreach (Collider2D hitObject in hitObjects)
        {
            //IDamageable iDamageableScript = hitObject.gameObject.GetComponent<IDamageable>();
            //iDamageableScript?.Damage(explosionDamage, gameObject);
            hitObject.gameObject.GetComponent<IDamageable>()?.Damage(explosionDamage, gameObject);
        }
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        NSM = true;
        audioSource.clip = explosao;
        audioSource.Play();
        Destroy(gameObject);
    }
    
    public void Damage(float damageAmount, GameObject sender)
    {
        hp -= damageAmount;
        
        if (hp <= 0)
        {
           SlowMotion();
            
        }
    }
}
