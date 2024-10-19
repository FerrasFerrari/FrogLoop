using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPoint;
    public Animator attackPointAnimator;
    public float attackRange = 0.5f;
    public float attackDamage = 1f;
    public LayerMask enemyMask;

    public Animator playerAnimator;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Camera sceneCamera;
    private Vector2 mousePosition;
    public Rigidbody2D rb;
    public GameObject rotationPoint;

    private void Start() {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Time.time >= nextAttackTime){

            if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)){

                RotateAttackPoint();
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                
            }
        }  
    }

    void Attack(){

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyMask);
        attackPointAnimator.SetBool("Attack", true);
        playerAnimator.SetBool("Attack", true);

        foreach (Collider2D enemy in hitEnemies){
            enemy.gameObject.GetComponent<IDamageable>().Damage(attackDamage);            
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
        // if(Time.time >= nextAttackTime){
            playerAnimator.SetFloat("AimHorizontal", Mathf.Sin(aimAngle));
            playerAnimator.SetFloat("AimVertical", Mathf.Cos(aimAngle));
        // }    
    }
}
