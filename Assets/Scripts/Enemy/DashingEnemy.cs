using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashingEnemy : MonoBehaviour
{
    public float speed;
    public float dashRate;
    private float nextDashTime;
    [SerializeField]private float lineOfSite;
    [SerializeField]private float dashingRange;
    [SerializeField]private float dashSpeed;
    [SerializeField]private float dashDuration;
    [SerializeField]private float dashDelay;
    private Transform player;
    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > dashingRange)
        {
            animator.SetBool("isAttacking", false);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= lineOfSite && nextDashTime < Time.time)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isAttacking", true);
            StartCoroutine(Attack());
            Debug.Log("Dash");
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
        speed *= .2f;
        yield return new WaitForSeconds(.8f);
        speed /= .2f;
    }
    private IEnumerator Attack(){
        Vector2 direction = -(transform.position - player.gameObject.transform.position).normalized;
        yield return new WaitForSeconds(dashDelay);
        rb.velocity = direction * dashSpeed;
    }
}
