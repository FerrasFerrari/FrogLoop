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

    }
}
