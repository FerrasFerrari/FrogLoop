using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    [SerializeField]
    private float parryRange = 1.2f;
    [SerializeField]
    private LayerMask hittablesMask;
    private float nextParryTime = 0f;
    [Tooltip("Cooldown between parrys")]
    public float parryCooldown = 1f;
    public float parryDelay = 0.15f;
    public float parriedBulletSpeedMultiplier = 1.5f;
    [SerializeField]private float enemyStunDuration;
    public float parryKnockback = 12f;

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

        Collider2D[] hittablesInRange = Physics2D.OverlapCircleAll(transform.position, parryRange, hittablesMask);

        List<int> hitEnemiesInstanceID = new();

        foreach(Collider2D hit in hittablesInRange){

            GameObject hitGameObject = hit.gameObject;

            if(!hitEnemiesInstanceID.Contains(hitGameObject.GetInstanceID())) { 
                hitEnemiesInstanceID.Add(hitGameObject.GetInstanceID());

                if(hit.gameObject.layer == LayerMask.NameToLayer("Bullet")){

                    Bullet bulletScript = hit.GetComponent<Bullet>();
                    //bullet.gameObject.GetComponent<SpriteRenderer>().color = new Color(62, 59, 102);
                    bulletScript.moveDir = (bulletScript.gameObject.transform.position - transform.position).normalized * bulletScript.speed * parriedBulletSpeedMultiplier;
                    
                    hit.gameObject.GetComponent<CircleCollider2D>().excludeLayers -= LayerMask.GetMask("Enemy");
                    bulletScript.Parry();
                    
                    bulletScript.BulletRB.velocity = new Vector2(bulletScript.moveDir.x, bulletScript.moveDir.y);

                }else{
                    hit.GetComponent<Knockbacker>().Knockback(parryKnockback, gameObject, enemyStunDuration);
                }
                
                audioSource.clip = parry;
                audioSource.Play();
            }
        }
        animator.SetBool("Parry", false);
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, parryRange);
    }
}
