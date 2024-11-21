using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    [SerializeField]
    private float parryRange = 1.2f;
    [SerializeField]
    private LayerMask bulletsMask;
    private float nextParryTime = 0f;
    [Tooltip("Cooldown between parrys")]
    public float parryCooldown = 1f;
    public float parriedBulletSpeedMultiplier = 1.5f;
    public float parryDelay = 0.15f;

    private Animator animator;

    public AudioSource audioSource;
    public AudioClip parry;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Time.time >= nextParryTime){
            if(Input.GetKeyDown(KeyCode.Mouse1)){
                animator.SetBool("Parry", true);
                StartCoroutine(Parry());
                nextParryTime = Time.time + parryCooldown;
            }
        }
    }
    public IEnumerator Parry(){
        yield return new WaitForSeconds(parryDelay);
        Collider2D[] bulletsInRange = Physics2D.OverlapCircleAll(transform.position, parryRange, bulletsMask);
        foreach(Collider2D bullet in bulletsInRange){
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            //bullet.gameObject.GetComponent<SpriteRenderer>().color = new Color(62, 59, 102);
            bulletScript.moveDir = (bulletScript.gameObject.transform.position - transform.position).normalized * bulletScript.speed * parriedBulletSpeedMultiplier;
            bullet.gameObject.GetComponent<Collider2D>().includeLayers += LayerMask.GetMask("Enemy");
            bullet.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            bulletScript.BulletRB.velocity = new Vector2(bulletScript.moveDir.x, bulletScript.moveDir.y);
            audioSource.clip = parry;
            audioSource.Play();
        }
        animator.SetBool("Parry", false);
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, parryRange);
    }
}
