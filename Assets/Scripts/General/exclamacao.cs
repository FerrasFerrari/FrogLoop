using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exclamacao : MonoBehaviour
{
    public GameObject TelaExplicaçao;
    public Button exclacacoBTN;
    public AudioSource audioSource;
    public AudioClip PickUp;
    // Start is called before the first frame update
    void Start()
    {
        TelaExplicaçao.SetActive(false);
        exclacacoBTN.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            TelaExplicaçao.SetActive(true);
            Time.timeScale = 0;
            audioSource.clip = PickUp;
            audioSource.Play();
            exclacacoBTN.enabled = true;
            Destroy(gameObject);
        }
    }
}
