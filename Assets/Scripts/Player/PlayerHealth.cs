using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField]private float immunityDuration;
    [SerializeField]private float hitStopDuration = 0.35f;
    [SerializeField]private float deathStopDuration = 1.2f;
    [SerializeField]private float delayBeforeGameOver;
    [HideInInspector]public bool isOnImmunity = false;
    [HideInInspector]public bool dead = false;
    public HealthBar HealthBarScript;
    public PlayerMovement PlayerMovementScript;
    public AudioSource audioSource;
    public AudioClip dano, morte;
    void Start()
    {
        HealthBarScript.Life = 6;
        PlayerMovementScript.Intangivel = false;
    }

    void Update()
    {
        if(HealthBarScript.Life <= 0 && !dead)
        {
            dead = true;
            audioSource.clip = morte;
            audioSource.Play();
            StartCoroutine(WaitForTimescale());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (PlayerMovementScript.Intangivel == false)
        {
            if (collision.gameObject.tag.Equals("Bullet"))
            {
                HealthBarScript.Life = HealthBarScript.Life - 1;
            }
        }*/
    }

    public void Damage(float damageAmount, GameObject sender)
    {
        if (PlayerMovementScript.Intangivel == false)
        {
            StartCoroutine(TakeDamage(damageAmount));
        }
    }

    private IEnumerator TakeDamage(float damageAmount)
    {
        GetComponent<DamageFlash>().CallDamageFlasher();
        int damageTaken = Mathf.FloorToInt(damageAmount);
        if(HealthBarScript.Life - damageTaken <= 0){
            damageTaken = HealthBarScript.Life;
            HitStop.Instance.Stop(deathStopDuration);
        }else{
            HitStop.Instance.Stop(hitStopDuration);
        }


        HealthBarScript.Life -= damageTaken;

        audioSource.clip = dano;
        audioSource.Play();

        GetComponent<CapsuleCollider2D>().enabled = false;
        isOnImmunity = true;

        yield return new WaitForSeconds(immunityDuration);
        
        GetComponent<CapsuleCollider2D>().enabled = true;
        isOnImmunity = false;
    }
    IEnumerator WaitForTimescale(){
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach(Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
        while(Time.timeScale != 1f){
            yield return null;
        }
        //yield return new WaitForSecondsRealtime(delayBeforeGameOver);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
