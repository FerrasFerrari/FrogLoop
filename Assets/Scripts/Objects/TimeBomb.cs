using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float hp = 1;
    public AudioSource audioSource;
    public AudioClip explosao;
    [SerializeField] private Material backgroundMaterial;
    [SerializeField] private Color backgroundColor;

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
        HitStop.Instance.Stop(2f, 0.5f);
        // Time.timeScale = 0.5f;
        // Time.fixedDeltaTime = Time.timeScale * .02f;
        NSM = true;
        StartCoroutine(WaitForTimescale(backgroundPreviousColor));
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
    private IEnumerator WaitForTimescale(Color color){
        Debug.Log("TryChangeColor");
        while(Time.timeScale != 1f)
            yield return null;
        Debug.Log("ChangeColor");
        backgroundMaterial.color = color;
    }
}
