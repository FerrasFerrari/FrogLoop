using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockBow : MonoBehaviour
{
    public bool Unlocked;
    public TMP_Text BowText;
    public TMP_Text BowBtnText;
    public Button BowBtn;
    // Start is called before the first frame update
    void Start()
    {
        Unlocked = false;
       BowText.enabled = false;
       BowBtnText.enabled = false;
       BowBtn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Unlocked = true;
            BowBtn.enabled = true;
            BowBtnText.enabled = true;
            BowText.enabled = true;
            
            Destroy(gameObject);
        }
    }
    
}
