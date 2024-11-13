using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar HealthBarScript;
    public PlayerMovement PlayerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarScript.Life = 5;
        PlayerMovementScript.Intangivel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthBarScript.Life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerMovementScript.Intangivel == false)
        {
            if (collision.gameObject.tag.Equals("Bullet"))
            {
                //HealthBarScript.Life = HealthBarScript.Life - 1;
            }
        }
    }
}
