using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPoint;
    public Animator attackPointAnimator;
    public float attackRange = 0.75f;
    public float attackDamage = 1f;
    [SerializeField]private Vector3 rangeOffset;
    public LayerMask hittableMask;
    public Vector2 aimDirection;
    float aimAngle;

    public float attackingMovingSpeedMultiplier = 0.15f;
    public float attackMovementSlowDuration = 0.33f;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    private PlayerMovement playerMovementScript;
    [SerializeField]private Camera sceneCamera;
    private Animator playerAnimator;
    private Vector2 mousePosition;
    private Rigidbody2D rb;
    public GameObject rotationPoint;

    private void Start() {
        playerMovementScript = GetComponent<PlayerMovement>();
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Time.time >= nextAttackTime){

            if(Input.GetKey(KeyCode.Space) && !playerMovementScript.isDashing || Input.GetMouseButton(0) && !playerMovementScript.isDashing){
                StartCoroutine(AttackMovementSlowdown(attackMovementSlowDuration));
                RotateAttackPoint();
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                
            }
        }  
    }

    void Attack(){

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position + rangeOffset, attackRange, hittableMask);
        attackPointAnimator.SetBool("Attack", true);
        playerAnimator.SetBool("Attack", true);

        foreach (Collider2D enemy in hitEnemies){
            enemy.gameObject.GetComponent<IDamageable>().Damage(attackDamage, aimAngle, gameObject);
            enemy.gameObject.GetComponent<ScreenShaker>().Shake(aimDirection);
            if(enemy.gameObject.layer == LayerMask.NameToLayer("Enemy")){
                enemy.gameObject.GetComponent<Knockbacker>().Knockback(aimAngle, gameObject);
            }
        }

    }
    private IEnumerator AttackMovementSlowdown(float duration){
        playerMovementScript.activeMoveSpeed *= attackingMovingSpeedMultiplier;
        yield return new WaitForSeconds(duration);
        playerMovementScript.activeMoveSpeed = playerMovementScript.moveSpeed;
    }
    void OnDrawGizmosSelected(){
        if(attackPoint == null){ return; }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position + rangeOffset, attackRange);
    }

    void RotateAttackPoint()
    {
        rotationPoint.transform.position = transform.position;
        aimDirection = mousePosition - rb.position;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        rotationPoint.GetComponent<Rigidbody2D>().rotation = aimAngle;

        // if(Time.time >= nextAttackTime){
            playerAnimator.SetFloat("AimHorizontal", Mathf.Sin(aimAngle));
            playerAnimator.SetFloat("AimVertical", Mathf.Cos(aimAngle));
        // }    
    }
}
