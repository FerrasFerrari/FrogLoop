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
        Life = 6;
    }

    // Update is called once per frame
    void Update()
    {

        imageComp.sprite = Barradevida[Life];


        /*if(b)
        Barradevida[0].enabled = false; 
        if (Life == 0)
        {
            BarraVidaSapo_1.enabled = false;
            BarraVidaSapo_2.enabled = false;
            BarraVidaSapo_3.enabled = false;
            BarraVidaSapo_4.enabled = false;
            BarraVidaSapo_5.enabled = false;
            BarraVidaSapo_0.enabled = false;
             BarraVidaSapo_6.enabled = true;
        }
        if (Life == 1)
        {
            BarraVidaSapo_1.enabled = true;
            BarraVidaSapo_2.enabled = false;
            BarraVidaSapo_3.enabled = false;
            BarraVidaSapo_4.enabled = false;
            BarraVidaSapo_5.enabled = false;
            BarraVidaSapo_0.enabled = false;
            BarraVidaSapo_6.enabled = false;

        }
        if (Life == 2)
        {
            BarraVidaSapo_1.enabled = false;
            BarraVidaSapo_2.enabled = true;
            BarraVidaSapo_3.enabled = false;
            BarraVidaSapo_4.enabled = false;
            BarraVidaSapo_5.enabled = false;
            BarraVidaSapo_0.enabled = false;
            BarraVidaSapo_6.enabled = false;

        }
        if (Life == 3)
        {
            BarraVidaSapo_1.enabled = false;
            BarraVidaSapo_2.enabled = false;
            BarraVidaSapo_3.enabled = true;
            BarraVidaSapo_4.enabled = false;
            BarraVidaSapo_5.enabled = false;
            BarraVidaSapo_0.enabled = false;
            BarraVidaSapo_6.enabled = false;
        }
        if (Life == 4)
        {
            BarraVidaSapo_1.enabled = false;
            BarraVidaSapo_2.enabled = false;
            BarraVidaSapo_3.enabled = false;
            BarraVidaSapo_4.enabled = true;
            BarraVidaSapo_5.enabled = false
            BarraVidaSapo_0.enabled = false;
            BarraVidaSapo_6.enabled = false;
        }
        if (Life == 5)
        {
            BarraVidaSapo_1.enabled = false;
            BarraVidaSapo_2.enabled = false;
            BarraVidaSapo_3.enabled = false;
            BarraVidaSapo_4.enabled = false;
            BarraVidaSapo_5.enabled = true;
            BarraVidaSapo_0.enabled = false;
            BarraVidaSapo_6.enabled = false;
        }
        if (Life == 6)
        {

            BarraVidaSapo_1.enabled = false;
            BarraVidaSapo_2.enabled = false;
            BarraVidaSapo_3.enabled = false;
            BarraVidaSapo_4.enabled = false;
            BarraVidaSapo_5.enabled = false;
            BarraVidaSapo_0.enabled = true;
            BarraVidaSapo_6.enabled = false;
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
