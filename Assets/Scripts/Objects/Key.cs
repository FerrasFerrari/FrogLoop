using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int KeyNumber;
    public bool KeyOne;
    
    // Start is called before the first frame update
    void Start()
    {
        KeyOne = false;
       
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
          
        }
    }
}
