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
        UnlockBowScrpit.BowText.enabled = false;
        UnlockBowScrpit.BowBtnText.enabled = false;
        UnlockBowScrpit.BowBtn.enabled = false;

        UnlockDashScript.DashTXT.enabled = false;
        UnlockDashScript.DashBtnTXT.enabled = false;
        UnlockDashScript.DashBtn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BtnClickedBow ()
    {
        if(UnlockBowScrpit.BowText.enabled == true && UnlockBowScrpit.BowBtnText.enabled == true && UnlockBowScrpit.BowBtn.enabled == true)
        {
            UnlockBowScrpit.BowText.enabled = false;
            UnlockBowScrpit.BowBtnText.enabled = false;
            UnlockBowScrpit.BowBtn.enabled = false;
        }
    }

    public void BtnClickedDash()
    {
        if(UnlockDashScript.DashTXT.enabled == true && UnlockDashScript.DashBtnTXT.enabled == true && UnlockDashScript.DashBtn.enabled == true)
        {
            UnlockDashScript.DashTXT.enabled = false;
            UnlockDashScript.DashBtnTXT.enabled = false;
            UnlockDashScript.DashBtn.enabled = false;
        }
    }
}
