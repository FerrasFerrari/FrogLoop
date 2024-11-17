using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public UnlockBow UnlockBowScrpit;
    public UnlockDash UnlockDashScript;
    // Start is called before the first frame update
    void Start()
    {
        UnlockBowScrpit.telaArco.SetActive(false);
        UnlockBowScrpit.BowBtn.enabled = false;

        UnlockDashScript.telaDash.SetActive(false);
        UnlockDashScript.DashBtn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BtnClickedBow ()
    {
        if(UnlockBowScrpit.BowBtn.enabled == true && UnlockBowScrpit.telaArco.activeSelf == true)
        {
            UnlockBowScrpit.telaArco.SetActive(false);
             UnlockBowScrpit.BowBtn.enabled = false;
            Time.timeScale = 1;
        }
    }

    public void BtnClickedDash()
    {
        if(UnlockDashScript.DashBtn.enabled == true && UnlockDashScript.telaDash.activeSelf == true)
        {
            UnlockDashScript.telaDash.SetActive(false);
            UnlockDashScript.DashBtn.enabled = false;
            Time.timeScale = 1;
        }
    }
}
