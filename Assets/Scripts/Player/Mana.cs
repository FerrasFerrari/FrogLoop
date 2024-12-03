using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float mana = 0;
    public float bowCost = 2;
    [SerializeField]private ManaBar manaBarScript;
    private Bow bowScript;
    private void Awake() {
        bowScript = GetComponent<Bow>();
    }

    public void AddMana(float amount){
        if(amount > 0){
            if(mana >= (bowCost * 4)) { return; }
        }
        mana += amount;
        manaBarScript.mana = mana;
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
