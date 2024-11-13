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
    public bool Spawn1;
    public bool Spawn2;
    public bool Spawn3;
    public int TowerSpawn;


    void Start()
    {
        anim = GetComponent<Animator>();
        gateDestroier = GameObject.FindGameObjectWithTag("Gate").GetComponent<GateDestroier>();
        Spawn1 = true;
        Spawn2 = true;
        Spawn3 = true;
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
        if(TowerSpawn == 1)
        {
            Spawn1 = false;
        }
        if(TowerSpawn == 2)
        {
            Spawn2 = false;
        }
        if(TowerSpawn == 3)
        {
            Spawn3 = false;
        }
    }
}
