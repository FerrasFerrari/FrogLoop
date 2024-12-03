using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [HideInInspector]public float mana;
    public Sprite[] manaSprites;
    private Image imageComp;
    // Start is called before the first frame update
    void Start()
    {
        imageComp = GetComponent<Image>();
        mana = 0;
    }

    void Update()
    {

        imageComp.sprite = manaSprites[Mathf.FloorToInt(mana / 2)];

    }
}
