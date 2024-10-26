using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int KeyNumber;
    public bool KeyOne;
    public bool KeyTwo;
    public bool KeyThree;
    // Start is called before the first frame update
    void Start()
    {
        KeyOne = false;
        KeyTwo = false;
        KeyThree = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
        
            if(KeyNumber == 1)
            {
                KeyOne = true;
                Destroy(gameObject);
            }
            if (KeyNumber == 2)
            {
                KeyTwo = true;
                Destroy(gameObject);
            }
            if(KeyNumber == 3)
            {
                KeyThree = true;
                Destroy(gameObject);
            }
        }
    }
}
