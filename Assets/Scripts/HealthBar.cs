using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    int Life;
    public SpriteRenderer Barradevida1;
    public SpriteRenderer Barradevida2;
    public SpriteRenderer Barradevida3;
    public SpriteRenderer Barradevida4;
    public SpriteRenderer Barradevidavazia;
    public SpriteRenderer Barradevidacheia;
    // Start is called before the first frame update
    void Start()
    {
        Life = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Life == 0)
        {
            Barradevida1.enabled = false;
            Barradevida2.enabled = false;
            Barradevida3.enabled = false;
            Barradevida4.enabled = false;
            Barradevidacheia.enabled = false;
            Barradevidavazia.enabled = true;
            Destroy(gameObject);
        }
        if (Life == 1)
        {
            Barradevida1.enabled = true;
            Barradevida2.enabled = false;
            Barradevida3.enabled = false;
            Barradevida4.enabled = false;
            Barradevidacheia.enabled = false;
            Barradevidavazia.enabled = false;

        }
        if (Life == 2)
        {
            Barradevida1.enabled = false;
            Barradevida2.enabled = true;
            Barradevida3.enabled = false;
            Barradevida4.enabled = false;
            Barradevidacheia.enabled = false;
            Barradevidavazia.enabled = false;

        }
        if (Life == 3)
        {
            Barradevida1.enabled = false;
            Barradevida2.enabled = false;
            Barradevida3.enabled = true;
            Barradevida4.enabled = false;
            Barradevidacheia.enabled = false;
            Barradevidavazia.enabled = false;
        }
        if (Life == 4)
        {
            Barradevida1.enabled = false;
            Barradevida2.enabled = false;
            Barradevida3.enabled = false;
            Barradevida4.enabled = true;
            Barradevidacheia.enabled = false;
            Barradevidavazia.enabled = false;
        }
        if (Life == 5)
        {
            Barradevida1.enabled = false;
            Barradevida2.enabled = false;
            Barradevida3.enabled = false;
            Barradevida4.enabled = false;
            Barradevidacheia.enabled = true;
            Barradevidavazia.enabled = false;
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
   // {
       // if (collision.gameObject.tag.Equals("Enemy"))
        //{
         //   Life = Life - 1;

        //}
    //}
}
