using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilitySpriteChanger : MonoBehaviour
{
    private Image imagecomponent;
    [SerializeField]private Sprite unusuableSprite;
    private Sprite usuableSprite;
    private void Awake() {
        imagecomponent = GetComponent<Image>();
        usuableSprite = imagecomponent.sprite;
    }
    public void ChangeImage(bool usable){
        if(usable){
            imagecomponent.sprite = usuableSprite;
        }else{
            imagecomponent.sprite = unusuableSprite;
        }
    }
}
