using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float mana = 0;
    public float bowCost = 2;
    private Bow bowScript;
    private void Awake() {
        bowScript = GetComponent<Bow>();
    }

    public void AddMana(float amount){
        if(mana >= (bowCost * 3)) { return; }
        mana += amount;
    }
    public bool CanUseBow(){
        if(mana >= bowCost){
            AddMana(-bowCost);
            return true;
        }else{
            return false;
        }
    }
}
