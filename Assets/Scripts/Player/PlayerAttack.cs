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
    public float aimAngle;

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

    RaycastHit2D[] hitEnemies = new RaycastHit2D[10];

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



        //Physics2D.OverlapCircleNonAlloc(attackPoint.position + rangeOffset, attackRange, hitEnemies, hittableMask);

        Physics2D.CircleCastNonAlloc(attackPoint.position + rangeOffset, attackRange, aimDirection, hitEnemies, hittableMask);
        List<GameObject> hitEnemiesGameObjects = new();
        attackPointAnimator.SetBool("Attack", true);
        playerAnimator.SetBool("Attack", true);

       
        for(int i = 0; i < hitEnemies.Length; i++) {
            if (hitEnemies[i])
            {
                if (hitEnemiesGameObjects.Contains(hitEnemies[i].collider.gameObject)) { return; }
                hitEnemiesGameObjects.Add(hitEnemies[i].collider.gameObject);

                hitEnemies[i].collider.gameObject.GetComponent<IDamageable>().Damage(attackDamage, gameObject);
                hitEnemies[i].collider.gameObject.GetComponent<ScreenShaker>().ShakeDirectional(aimDirection);

                if (hitEnemies[i].collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    hitEnemies[i].collider.gameObject.GetComponent<Knockbacker>().Knockback(aimAngle, gameObject);
                }
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

    public void RotateAttackPoint()
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
