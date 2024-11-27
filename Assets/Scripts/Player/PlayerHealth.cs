using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField]private float immunityDuration;
    [HideInInspector]public bool isOnImmunity = false;
    public HealthBar HealthBarScript;
    public PlayerMovement PlayerMovementScript;
    public AudioSource audioSource;
    public AudioClip dano, morte;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarScript.Life = 6;
        PlayerMovementScript.Intangivel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthBarScript.Life <= 0)
        {
            audioSource.clip = morte;
            audioSource.Play(); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        HitStop.Instance.Stop(0.3f);

        HealthBarScript.Life = HealthBarScript.Life - Mathf.FloorToInt(damageAmount);

        audioSource.clip = dano;
        audioSource.Play();

        GetComponent<CapsuleCollider2D>().enabled = false;
        isOnImmunity = true;

        yield return new WaitForSeconds(immunityDuration);
        
        GetComponent<CapsuleCollider2D>().enabled = true;
        isOnImmunity = false;
    }
}
