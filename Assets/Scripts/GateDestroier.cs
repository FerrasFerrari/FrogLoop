using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDestroier : MonoBehaviour
{
    private bool[] towers = new bool[3];

    private void Start() {
        for(int i = 0; i < towers.Length; i++){
            towers[i] = false;
        }
    }
    public void UpdateBrokenStatus(int index){
        towers[index] = true;
        CheckNumberOfBrokenTowers();
    }
    private void CheckNumberOfBrokenTowers(){
        int nBrokenTowers = 0;
        foreach(bool tower in towers){
            if(tower){
                nBrokenTowers++;
            }
        }
        if(nBrokenTowers == towers.Length){
            DestroyGate();
        }
    }
     private void DestroyGate(){
        Destroy(gameObject);
    }
}
