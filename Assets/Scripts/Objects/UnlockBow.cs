using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockBow : MonoBehaviour
{
    public bool Unlocked;
    
    public Button BowBtn;
    public GameObject telaArco;
    // Start is called before the first frame update
    void Start()
    {
        Unlocked = false;
        telaArco.active = false;
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
           telaArco.active = true;
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
    
}
