using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    public HealthBar HealthBarScript;
    public AudioSource audioSource;
    public AudioClip vidaColetada;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarScript.Life = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if(HealthBarScript.Life < 6)
            {
                HealthBarScript.Life = HealthBarScript.Life + 1;
                audioSource.clip = vidaColetada;
                audioSource.Play();
                Destroy(gameObject);
            }
        }
    }
}
