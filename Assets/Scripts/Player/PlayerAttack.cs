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
    [SerializeField]private float attackKnockbackMultiplier = 10f;
    [SerializeField]private Vector3 rangeOffset;
    public LayerMask hittableMask;
    [HideInInspector] public Vector2 aimDirection;
    [HideInInspector] public float aimAngle;

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

    public AudioSource audioSource;
    public AudioClip attackSFX;


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

        RaycastHit2D[] hitEnemies = Physics2D.CircleCastAll(transform.position, attackRange, aimDirection, 
        Vector3.Distance(transform.position, attackPoint.position + rangeOffset), hittableMask);

        List<int> hitEnemiesInstanceID = new();

        attackPointAnimator.SetBool("Attack", true);
        playerAnimator.SetBool("Attack", true);

        audioSource.clip = attackSFX;
        audioSource.Play(); 

        for(int i = 0; i < hitEnemies.Length; i++) {
            GameObject enemyGameObject = hitEnemies[i].collider.gameObject;
            if(!hitEnemiesInstanceID.Contains(enemyGameObject.GetInstanceID())) { 
                hitEnemiesInstanceID.Add(enemyGameObject.GetInstanceID());

                enemyGameObject.GetComponent<IDamageable>().Damage(attackDamage, gameObject);
                enemyGameObject.GetComponent<ScreenShaker>().ShakeDirectional(aimDirection);
                enemyGameObject.GetComponent<Knockbacker>()?.Knockback(attackKnockbackMultiplier, gameObject);
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
        playerAnimator.SetFloat("AimHorizontal", Mathf.RoundToInt(Mathf.Sin(aimAngle)));
        playerAnimator.SetFloat("AimVertical", Mathf.RoundToInt(Mathf.Cos(aimAngle)));
        // }    
    }
}
