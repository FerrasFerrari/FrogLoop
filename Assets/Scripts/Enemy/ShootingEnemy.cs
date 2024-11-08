using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed;
    public float fireRate;
    private float nextFireTime;
    public float lineOfSite;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    private Animator animator;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            animator.SetBool("isAttacking", false);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= lineOfSite && nextFireTime < Time.time)
        {
            animator.SetBool("isAttacking", true);
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
}
