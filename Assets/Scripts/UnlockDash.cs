using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDash : MonoBehaviour
{
    public bool UnlockedSprint;
    // Start is called before the first frame update
    void Start()
    {
        UnlockedSprint = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            UnlockedSprint = true;
            Destroy(gameObject);
        }
    }
}
