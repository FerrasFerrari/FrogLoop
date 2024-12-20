using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    [SerializeField]
    private float parryRange = 1.2f;
    [SerializeField]
    private LayerMask hittablesMask;
    private float nextParryTime = 0f;
    [Tooltip("Cooldown between parrys")]
    public float parryCooldown = 1f;
    [SerializeField]private float _parryDuration;
    private bool _parry;
    public float parriedBulletSpeedMultiplier = 1.5f;
    [SerializeField]private float enemyStunDuration;
    public float parryKnockback = 12f;

    private List<Collider2D> _hittablesInRange = new();
    private List<int> hitEnemiesInstanceID = new();
    private bool gottenMana = false;

    private Animator animator;
    [SerializeField]private UIAbilitySpriteChanger uiElement;

    public AudioSource audioSource;
    public AudioClip parry;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Time.time >= nextParryTime){

            uiElement.ChangeImage(true);

            if(Input.GetKeyDown(KeyCode.Mouse1)){

                uiElement.ChangeImage(false);
                animator.SetBool("Parry", true);

                StartCoroutine(StartParry());

                nextParryTime = Time.time + parryCooldown;
            }
        }
    }

    private void LateUpdate() {
        if(_parry){
            GetHittables();
            Parry();
        }
    }
    private IEnumerator StartParry(){
        _parry = true;

        audioSource.clip = parry;
        audioSource.Play();

        yield return new WaitForSeconds(_parryDuration);

        _parry = false;
        animator.SetBool("Parry", false);
        
        _hittablesInRange.Clear();
    }
    
    private void GetHittables(){
        Collider2D[] h = Physics2D.OverlapCircleAll(transform.position, parryRange, hittablesMask);
        for(int i = 0; i < h.Length; i++){
            _hittablesInRange.Add(h[i]);
        }
    }
    public void Parry(){

        foreach(Collider2D hit in _hittablesInRange){

            GameObject hitGameObject = hit.gameObject;

            if(!hitEnemiesInstanceID.Contains(hitGameObject.GetInstanceID())) { 
                hitEnemiesInstanceID.Add(hitGameObject.GetInstanceID());

                if(hit.gameObject.layer == LayerMask.NameToLayer("Bullet")){
                    if(!gottenMana){
                        GetComponent<Mana>().AddMana(1);
                        gottenMana = true;
                    }

                    Bullet bulletScript = hit.GetComponent<Bullet>();

                    hit.gameObject.GetComponent<CircleCollider2D>().excludeLayers -= LayerMask.GetMask("Enemy");
                    hit.gameObject.GetComponent<CircleCollider2D>().excludeLayers -= LayerMask.GetMask("Boss");
                    bulletScript.Parry();

                    bulletScript.moveDir = bulletScript.speed * parriedBulletSpeedMultiplier 
                    * (bulletScript.gameObject.transform.position - transform.position).normalized;
                    
                    bulletScript.BulletRB.velocity = new Vector2(bulletScript.moveDir.x, bulletScript.moveDir.y);

                }else{
                    hit.GetComponent<Knockbacker>().Knockback(parryKnockback, gameObject, enemyStunDuration);
                }
                
            }
        } 
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, parryRange);
    }
}
