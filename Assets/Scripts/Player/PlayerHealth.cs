using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
        if(HealthBarScript.Life <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            HealthBarScript.Life = HealthBarScript.Life - 1;
        }
    }
}
