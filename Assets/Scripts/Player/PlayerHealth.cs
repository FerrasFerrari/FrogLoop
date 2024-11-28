using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField]private float immunityDuration = 1.2f;
    [SerializeField]private int numberOfFlicks = 4;
    [SerializeField]private float hitStopDuration = 0.35f;
    [SerializeField]private Color deathFlashColor = Color.red;
    [SerializeField]private float deathStopDuration = 1.2f;
    //[SerializeField]private float delayBeforeGameOver;
    [HideInInspector]public bool isOnImmunity = false;
    [HideInInspector]public bool dead = false;
    private DamageFlash damageFlashScript;
    public HealthBar HealthBarScript;
    public PlayerMovement PlayerMovementScript;
    public AudioSource audioSource;
    public AudioClip dano, morte;
    void Start()
    {
        damageFlashScript = GetComponent<DamageFlash>();
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
            StartCoroutine(WaitForTimescaleDeath());
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
        int damageTaken = Mathf.FloorToInt(damageAmount);
        if(HealthBarScript.Life - damageTaken <= 0){
            damageTaken = HealthBarScript.Life;
            damageFlashScript.flashColor = deathFlashColor;
            damageFlashScript.CallDamageFlasher();
            HitStop.Instance.Stop(deathStopDuration);
        }else{
            damageFlashScript.CallDamageFlasher();
            HitStop.Instance.Stop(hitStopDuration);
        }
        HealthBarScript.Life -= damageTaken;

        audioSource.clip = dano;
        audioSource.Play();

        GetComponent<CapsuleCollider2D>().enabled = false;
        isOnImmunity = true;
        StartCoroutine(TransparencyFlicker());
        yield return new WaitForSeconds(immunityDuration);
        
        GetComponent<CapsuleCollider2D>().enabled = true;
        isOnImmunity = false;
    }
    IEnumerator WaitForTimescaleDeath(){
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
    IEnumerator TransparencyFlicker(){
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        while(Time.timeScale != 1f){
            yield return null;
        }
        for(int i = 0; i < numberOfFlicks; i++){
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(immunityDuration / (2*numberOfFlicks));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(immunityDuration / (2*numberOfFlicks));
        }
    }
}
