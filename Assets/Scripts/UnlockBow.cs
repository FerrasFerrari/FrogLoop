using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBow : MonoBehaviour
{
    public bool Unlocked;
    // Start is called before the first frame update
    void Start()
    {
        Unlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Unlocked = true;
            Destroy(gameObject);
        }
    }
}
