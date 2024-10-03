using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7;
    public Rigidbody2D rb;
    public Camera sceneCamera;
    private Vector2 mousePosition;
    Vector2 moveDirection;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = .3f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;
    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    void Update()
    {
        
    }
    private void LateUpdate() {
            Inputs();
            Move();

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime; 
        }
    }
    void Inputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    void Move(){
        rb.velocity = new Vector2(moveDirection.x * activeMoveSpeed, moveDirection.y * activeMoveSpeed);
    }
    void RotateAttackPoint(Vector3 attackPoint, Vector3 axis, float angle){
        Vector2 aimDirection = mousePosition - rb.position; 
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
    }
}
