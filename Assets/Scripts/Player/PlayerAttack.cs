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
    [SerializeField]private float attackDelay;
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
                RotateAttackPoint2();
                StartCoroutine(Attack());
                nextAttackTime = Time.time + 1f / attackRate;
                
            }
        }  
    }

    IEnumerator Attack(){
        //Physics2D.OverlapCircleNonAlloc(attackPoint.position + rangeOffset, attackRange, hitEnemies, hittableMask);
        attackPointAnimator.SetBool("Attack", true);
        playerAnimator.SetBool("Attack", true);

        audioSource.clip = attackSFX;
        audioSource.Play(); 

        yield return new WaitForSeconds(attackDelay);

        RaycastHit2D[] hitEnemies = Physics2D.CircleCastAll(transform.position, attackRange, aimDirection, 
        Vector3.Distance(transform.position, attackPoint.position + rangeOffset), hittableMask);

        List<int> hitEnemiesInstanceID = new();


        for(int i = 0; i < hitEnemies.Length; i++) {
            GameObject enemyGameObject = hitEnemies[i].collider.gameObject;
            if(!hitEnemiesInstanceID.Contains(enemyGameObject.GetInstanceID())) { 
                hitEnemiesInstanceID.Add(enemyGameObject.GetInstanceID());

                enemyGameObject.GetComponent<IDamageable>().Damage(attackDamage, gameObject);
                enemyGameObject.GetComponent<ScreenShaker>()?.ShakeDirectional(aimDirection);
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
        playerAnimator.SetFloat("AimHorizontal", Mathf.RoundToInt(Mathf.Cos(aimAngle)));
        playerAnimator.SetFloat("AimVertical", Mathf.RoundToInt(Mathf.Sin(aimAngle)));
        // }    
    }

    public void RotateAttackPoint2(){

        rotationPoint.transform.position = transform.position;
        aimDirection = mousePosition - rb.position;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        rotationPoint.GetComponent<Rigidbody2D>().rotation = aimAngle;
        Vector3 playerPositionPixels = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseDirection = (Input.mousePosition - playerPositionPixels).normalized;

        float dotProductRight = Vector3.Dot(Vector3.right, mouseDirection);
        float dotProductUp = Vector3.Dot(Vector3.up, mouseDirection);

        Debug.Log(dotProductUp);
        if(dotProductRight > 0){
            GetComponent<SpriteRenderer>().flipX = false;
        }else{
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (dotProductUp > 0.33)
        {
            if (dotProductUp > 0.66){
                playerAnimator.SetFloat("AimVertical", 1);
                playerAnimator.SetFloat("AimHorizontal", 0);
            }else{
                playerAnimator.SetFloat("AimVertical", 1);
                playerAnimator.SetFloat("AimHorizontal", 1);
            }
        }
        else if (dotProductUp < -0.7)
        {
            Debug.Log("Down");
            playerAnimator.SetFloat("AimVertical", -1);
            playerAnimator.SetFloat("AimHorizontal", 0);

        }
        else if (dotProductUp < 0.6)
        {
            playerAnimator.SetFloat("AimVertical", 0);
            playerAnimator.SetFloat("AimHorizontal", 1);
           // Debug.Log("Up");
        }
        else if (dotProductUp > -0.6)
        {
            playerAnimator.SetFloat("AimVertical", 0);
            playerAnimator.SetFloat("AimHorizontal", 1);
        }

    }
}
