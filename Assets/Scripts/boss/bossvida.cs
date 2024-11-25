using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossvida : MonoBehaviour, IDamageable
{
    public BossBarra BossBarraScript;
    public AudioSource audioSource;
    public AudioClip dano, morte;
    // Start is called before the first frame update
    void Start()
    {
        BossBarraScript.healthAmount = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(BossBarraScript.healthAmount <= 0)
        {
            audioSource.clip = morte;
            audioSource.Play();
            Destroy(gameObject);
        }
    }
    public void Damage(float damageAmount, GameObject sender)
    {
        BossBarraScript.healthAmount -= damageAmount;
        audioSource.clip = dano;
        audioSource.Play();
        BossBarraScript.BarraVidaFG.fillAmount = BossBarraScript.healthAmount / 100f;
    }
}
