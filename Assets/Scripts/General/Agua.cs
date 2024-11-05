using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Agua : MonoBehaviour
{
    TilemapCollider2D _col;
    public PlayerMovement PlayerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementScript.Intangivel = false;
        _col = gameObject.GetComponent<TilemapCollider2D>();
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
