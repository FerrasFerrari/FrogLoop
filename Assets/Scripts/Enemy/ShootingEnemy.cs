using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour, IStunnable
{
    public float speed;
    public float fireRate;
    private float nextFireTime;
    public float lineOfSite;
    public float shootingRange;
    private bool hasEnteredLOA = false;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    private Animator animator;
    private Rigidbody2D rb;
    public AudioSource audioSource;
    public AudioClip tiro;
    private bool canAttack = true;

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioSourceMosca").GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            hasEnteredLOA = false;
            animator.SetBool("isAttacking", false);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= lineOfSite && nextFireTime < Time.time && canAttack)
        {
            if(!hasEnteredLOA){ rb.velocity = Vector2.zero; hasEnteredLOA = true; }
            animator.SetBool("isAttacking", true);
            audioSource.clip = tiro;
            audioSource.Play();
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + 1f / fireRate;
        }
        FlipXY();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    private void FlipXY(){
        float angle = Vector2.Angle(Vector2.right, player.position);
        if(angle > -90 && angle < 90){
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }else{
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }
    public IEnumerator Stun(float duration)
    {
        canAttack = false;
        StopAllCoroutines();
        speed *= .2f;
        yield return new WaitForSeconds(duration);
        speed /= .2f;
        canAttack = true;
    }

}
