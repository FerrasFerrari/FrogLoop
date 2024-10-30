using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockDash : MonoBehaviour
{
    public bool UnlockedSprint;
    public TMP_Text DashTXT;
    public TMP_Text DashBtnTXT;
    public Button DashBtn;

    // Start is called before the first frame update
    void Start()
    {
        UnlockedSprint = false;
        DashTXT.enabled = false;
        DashBtnTXT.enabled = false;
        DashBtn.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            UnlockedSprint = true;
            DashTXT.enabled = true;
            DashBtnTXT.enabled = true;
            DashBtn.enabled = true;
            Destroy(gameObject);
        }
    }
}
