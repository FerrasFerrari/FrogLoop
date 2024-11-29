using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float hp = 1;
    [SerializeField]private GameObject explosionEffectPrefab;
    public AudioSource audioSource;
    public AudioClip explosao;

    [HideInInspector]public bool NSM;
    void Start()
    {
        NSM = false;
    }

    void Update()
    {

    }
    private void SlowMotion()
    {
        HitStop.Instance.Stop(2f, 0.5f);
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        // Time.timeScale = 0.5f;
        // Time.fixedDeltaTime = Time.timeScale * .02f;
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
