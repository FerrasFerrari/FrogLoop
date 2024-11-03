using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{
    BoxCollider2D _col;
    public PlayerMovement PlayerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementScript.Intangivel = false;
        _col = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovementScript.Intangivel == true)
        {
            _col.enabled = false;
        }
        if(PlayerMovementScript.Intangivel == false)
        {
            _col.enabled = true;    
        }
    }
}
