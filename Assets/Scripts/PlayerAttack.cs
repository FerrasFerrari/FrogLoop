using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackDamage = 1f;
    public LayerMask enemyMask;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Camera sceneCamera;
    private Vector2 mousePosition;
    public Rigidbody2D rb;
    public GameObject rotationPoint;
    ParticleSystem parS;
    public ParticleSystem parS2;


    private void Start()
    {
        parS = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        RotateAttackPoint();
        if (Time.time >= nextAttackTime){

            if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)){

                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                
            }
        }  
    }

    void Attack(){

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyMask);
        parS.Emit(1);

        foreach (Collider2D enemy in hitEnemies){
            enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }

    }
    void OnDrawGizmosSelected(){
        if(attackPoint == null){ return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void RotateAttackPoint()
    {
        rotationPoint.transform.position = transform.position;
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        rotationPoint.GetComponent<Rigidbody2D>().rotation = aimAngle;
    }
}
