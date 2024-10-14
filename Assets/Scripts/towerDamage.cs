using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerDamage : MonoBehaviour
{

    public float TowerHP = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeHit(float damage)
    {
        TowerHP -= damage;
        if (TowerHP <= 0)
        {
            Break();
        }
    }

    public void Break()
    {
        Destroy(gameObject);
    }
}
