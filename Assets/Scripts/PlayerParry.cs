using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    [SerializeField]
    private float parryRange = 1.2f;
    [SerializeField]
    private LayerMask bulletsMask;
    private float nextParryTime = 0f;
    public float parryCooldown = 1f;
    public float parriedBulletSpeedMultiplier = 1.5f;

    void Update()
    {
        if(Time.time >= nextParryTime){
            if(Input.GetKeyDown(KeyCode.Mouse1)){
                Parry();
                nextParryTime = Time.time + parryCooldown;
            }
        }
    }
    public void Parry(){
        Collider2D[] bulletsInRange = Physics2D.OverlapCircleAll(transform.position, parryRange, bulletsMask);
        foreach(Collider2D bullet in bulletsInRange){
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            //bullet.gameObject.GetComponent<SpriteRenderer>().color = new Color(62, 59, 102);
            bulletScript.moveDir *= -parriedBulletSpeedMultiplier;
            bulletScript.BulletRB.velocity = new Vector2(bulletScript.moveDir.x, bulletScript.moveDir.y);
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, parryRange);
    }
}
