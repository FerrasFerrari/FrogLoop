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
    public AudioSource audioSource;
    public AudioClip BowSound;
    // Start is called before the first frame update
    void Start()
    {
        Unlocked = false;
        telaArco.SetActive(false);
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
            telaArco.SetActive(true);
            Time.timeScale = 0;
            audioSource.clip = BowSound;
            audioSource.Play();
            Destroy(gameObject);
        }
    }
    
}
