using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    public HealthBar HealthBarScript;
    public AudioSource audioSource;
    public AudioClip vidaColetada;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if(HealthBarScript.Life < 6)
            {
                HealthBarScript.Life++;
                audioSource.clip = vidaColetada;
                audioSource.Play();
                Destroy(gameObject);
            }
        }
    }
}
