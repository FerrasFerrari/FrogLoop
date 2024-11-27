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
    [SerializeField] private Material backgroundMaterial;
    [SerializeField] private Color backgroundColor;
    [SerializeField] private BackToNormal backToNormalScript;

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
        Color backgroundPreviousColor = backgroundMaterial.color;
        backgroundMaterial.color = backgroundColor;
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        NSM = true;
        backToNormalScript.timescaleNormalize(backgroundMaterial, backgroundPreviousColor);
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
