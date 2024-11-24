using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossBarra : MonoBehaviour
{
    public TowerRoomTrigger TriggerScript;
    public Image BarraVidaBG;
    public Image BarraVidaFG;
    public TMP_Text NomeBoss;
    public float healthAmount = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        TriggerScript.BarraBoss = false;
       BarraVidaBG.enabled = false;
        BarraVidaFG.enabled = false;
        NomeBoss.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TriggerScript.BarraBoss == true)
        {
            BarraVidaFG.enabled = true;
            BarraVidaBG.enabled = true;
            NomeBoss.enabled = true;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }
    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        BarraVidaFG.fillAmount = healthAmount / 100f;
    }
   
}
