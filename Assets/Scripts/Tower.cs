using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IDamageable
{

    [SerializeField]private int towerNumber;
    [SerializeField]private int towerHP = 5;
    private Animator anim;
    private bool isBroken = false;
    private GateDestroier gateDestroier;


    void Start()
    {
        anim = GetComponent<Animator>();
        gateDestroier = GameObject.FindGameObjectWithTag("Gate").GetComponent<GateDestroier>();
    }

    void Update()
    {
        
    }
    public void Damage(float damageAmount, GameObject sender)
    {
        if(isBroken){ return; }
        towerHP--;
        if(towerHP <= 0){
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("isBroken", true);
        isBroken = true;
        gateDestroier.UpdateBrokenStatus(towerNumber - 1);
    }
}
