using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossBarra : MonoBehaviour
{
    public Trigger TriggerScript;
    public GameObject BarraVidaBG;
    public GameObject BarraVidaFG;
    public TMP_Text NomeBoss;
    // Start is called before the first frame update
    void Start()
    {
        TriggerScript.BarraBoss = false;
       BarraVidaBG.SetActive(false);
        BarraVidaFG.SetActive(false);
        NomeBoss.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(TriggerScript.BarraBoss == true)
        {
            
           BarraVidaBG.SetActive(true);
            BarraVidaFG.SetActive(true);
            NomeBoss.enabled = true;
        }
    }
}
