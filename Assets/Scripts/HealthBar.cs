using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int Life;
    public Sprite[] Barradevida;
    private Image imageComp;
    // Start is called before the first frame update
    void Start()
    {
        imageComp = GetComponent<Image>();
        Life = 5;
    }

    // Update is called once per frame
    void Update()
    {

        imageComp.sprite = Barradevida[Life];


        /*if(b)
        Barradevida[0].enabled = false; 
        if (Life == 0)
        {
            Barradevida1.enabled = false;
            Barradevida2.enabled = false;
            Barradevida3.enabled = false;
            Barradevida4.enabled = false;
            Barradevidacheia.enabled = false;
            Barradevidavazia.enabled = true;
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

        switch (Life)
        {
            // case 0:

        }*/
        
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    // {
    // if (collision.gameObject.tag.Equals("Enemy"))
    //{
    //   Life = Life - 1;

    //}
    //}
}
