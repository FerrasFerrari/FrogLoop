using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float moveSpeed = 7;
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
        Inputs();
    }
    private void LateUpdate() {
            
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

        SetAnimations(moveX, moveY, moveDirection);
    }

    private void SetAnimations(float x, float y, Vector2 mDirection)
    {
        anim.SetFloat("Horizontal", x);
        anim.SetFloat("Vertical", y);
        anim.SetFloat("Speed", mDirection.sqrMagnitude);
    }

    void Move(){
        rb.velocity = new Vector2(moveDirection.x * activeMoveSpeed, moveDirection.y * activeMoveSpeed);
    }
    
}
