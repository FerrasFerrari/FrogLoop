using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletPos;

    private float timer;
    private GameObject Player;
    public float FireDis;
    public AudioSource audioSource;
    public AudioClip tiro;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        

        if(distance < FireDis)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }
    }
    void shoot()
    {
        Instantiate(Bullet, BulletPos.position, Quaternion.identity);
        audioSource.clip = tiro;
        audioSource.Play();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, FireDis);
        
    }
}
