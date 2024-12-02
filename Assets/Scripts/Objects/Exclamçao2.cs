using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exclamçao2 : MonoBehaviour
{
    public GameObject TelaAtaques;
    public Button AtaquesBTN;
    public AudioSource audioSource;
    public AudioClip PickUp;
    // Start is called before the first frame update
    void Start()
    {
        TelaAtaques.SetActive(false);
        AtaquesBTN.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            TelaAtaques.SetActive(true);
            Time.timeScale = 0;
            audioSource.clip = PickUp;
            audioSource.Play();
            AtaquesBTN.enabled = true;
            Destroy(gameObject);
        }
    }
}
