using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    public HealthBar HealthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarScript.Life = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if(HealthBarScript.Life < 5)
            {
                HealthBarScript.Life = HealthBarScript.Life + 1;
                Destroy(gameObject);
            }
        }
    }
}
