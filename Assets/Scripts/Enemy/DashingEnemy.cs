using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashingEnemy : MonoBehaviour, IStunnable
{
    public float speed;
    public float dashRate;
    private float nextDashTime;
    [SerializeField]private float lineOfSite;
    [SerializeField]private float dashingRange;
    [SerializeField]private float dashSpeed;
    [SerializeField]private float dashDuration;
    [SerializeField]private float dashDelay;
    [SerializeField]private LayerMask noCollisionWhileDashing;
    private bool canAttack = true;
    private Collider2D[] colliders = new Collider2D[1];
    private Transform player;
    private Animator animator;
    private Rigidbody2D rb;
    public AudioSource audioSource;
    public AudioClip dashAudio;
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioSourceMosca").GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        colliders = GetComponents<Collider2D>();

    }
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > dashingRange)
        {
            animator.SetBool("Dash", false);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= lineOfSite && nextDashTime < Time.time && canAttack)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("Dash", true);
            StartCoroutine(Attack());
            StartCoroutine(Reset());
            nextDashTime = Time.time + 1f / dashRate;
        }
        FlipXY();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, dashingRange);
    }
    private void FlipXY(){
        float angle = Vector2.Angle(Vector2.right, player.position);
        if(angle > -90 && angle < 90){
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }else{
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }
    private IEnumerator Reset(){
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = Vector2.zero;
        SwitchCollisionWithOtherEntities(true);
        speed *= .2f;
        yield return new WaitForSeconds(.8f);
        speed /= .2f;
    }
    private IEnumerator Attack(){
        Vector2 direction = (player.gameObject.transform.position - transform.position).normalized;
        yield return new WaitForSeconds(dashDelay);
        audioSource.clip = dashAudio;
        audioSource.Play();
        rb.velocity = direction * dashSpeed;
        SwitchCollisionWithOtherEntities(false);
    }
    private void SwitchCollisionWithOtherEntities(bool b)
    {
        foreach (Collider2D collider in colliders)
        {
            if (!collider.isTrigger) {
                if(!b)
                {
                    collider.excludeLayers += noCollisionWhileDashing;
                }else
                {
                    collider.excludeLayers -= noCollisionWhileDashing;
                }
            }
        }
    }
    public IEnumerator Stun(float duration){
        canAttack = false;
        StopAllCoroutines();
        speed *= .2f;
        yield return new WaitForSeconds(duration);
        speed /= .2f;
        canAttack = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Assets")){
            other.gameObject.GetComponent<IDamageable>().Damage(2, gameObject);
        }
    }
}
