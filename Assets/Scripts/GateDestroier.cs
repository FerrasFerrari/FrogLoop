using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDestroier : MonoBehaviour
{
    public OpenGate OpenScript;
    // Start is called before the first frame update
    void Start()
    {
        OpenScript.Broken = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenScript.Broken == true)
        {
            Destroy(gameObject);
        }
    }
}
